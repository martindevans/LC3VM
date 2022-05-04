using LC3VM.Devices;
using LC3VM.Registers;
using LC3VM.Traps;

namespace LC3VM
{
    public class VM
    {
        #region fields and properties
        private readonly Dictionary<ushort, IMemoryMappedDevice> _memoryMap = new();
        private readonly Dictionary<ushort, ITrapHandler> _traps = new();

        public RegisterFile Registers { get; } = new RegisterFile();
        public ushort[] Memory { get; } = new ushort[65536];

        public bool Halted
        {
            get => ((Memory[0xFFFE] >> 15) & 0b1) == 0;
            set => Memory[0xFFFE] = (ushort)((Memory[0xFFFE] & 0x7FFF) | ((value ? 0 : 1) << 15));
        }
        public bool TimerInterruptEnable
        {
            get => (Memory[0xFFFE] & (1 << 14)) != 0;
            set => Memory[0xFFFE] = (ushort)((Memory[0xFFFE] & 0xBFFF) | ((value ? 1 : 0) << 14));
        }
        public ushort TimerInterval
        {
            get => (ushort)(Memory[0xFFFE] & 0x3FFF);
            set => Memory[0xFFFE] = (ushort)((Memory[0xFFFE] & 0xC000) | (value & 0x3FFF));
        }
        public ushort CycleCount
        {
            get => ReadMemory(0xFFFF);
            private set => WriteMemory(0xFFFF, value);
        }

        public ushort PC
        {
            get => Registers[Register.PC];
            private set => Registers[Register.PC] = value;
        }
        #endregion

        #region constructor
        public VM(params IMachineExtension[] devices)
        {
            foreach (var device in devices)
            {
                if (device is ITrapHandler th)
                    _traps.Add(th.TrapId, th);
                else if (device is IMemoryMappedDevice mm)
                    foreach (var addr in mm.Addresses)
                        _memoryMap.Add(addr, mm);
            }

            PC = 0x3000;
            Halted = false;

            Registers.IsSupervisorMode = false;
            Registers.PriorityLevel = 0;
            Registers.Condition = Condition.FL_ZRO;
        }
        #endregion

        public void LoadImage(Stream image)
        {
            using (var reader = new BinaryReader(image))
            {
                // the origin tells us where in memory to place the image
                var origin = Swap16(reader.ReadUInt16());

                // Calculate maximum possible number of bytes to read
                var bytesToRead = (Memory.Length - origin) * 2;

                // Read that many bytes (or less, if there weren't that many in the stream)
                var bytes = reader.ReadBytes(bytesToRead);

                // Copy the bytes into memory, swapping to big endian
                for (var i = 0; i < bytes.Length; i += 2)
                {
                    var a = bytes[i];
                    var b = bytes[i + 1];
                    var ab = (a << 8) | b;
                    Memory[i / 2 + origin] = unchecked((ushort)ab);
                }
            }

            static ushort Swap16(ushort x)
            {
                var a = x & byte.MaxValue;
                return unchecked((ushort)((a << 8) | (x >> 8)));
            }
        }

        public void Step()
        {
            if (Halted)
                return;

            // trigger timer interrupt 
            CycleCount++;
            if (TimerInterruptEnable && CycleCount >= TimerInterval)
                if (Interrupt(0x02, 1))
                    CycleCount = 0;

            var instr = ReadMemory(Registers[Register.PC]++);
            var op = (Opcode)(instr >> 12);

            switch (op)
            {
                case Opcode.OP_BR:
                    Branch(instr);
                    break;
                case Opcode.OP_ADD:
                    Add(instr);
                    break;
                case Opcode.OP_LD:
                    Load(instr);
                    break;
                case Opcode.OP_ST:
                    Store(instr);
                    break;
                case Opcode.OP_JSR:
                    JumpSubroutine(instr);
                    break;
                case Opcode.OP_AND:
                    And(instr);
                    break;
                case Opcode.OP_LDR:
                    LoadRegister(instr);
                    break;
                case Opcode.OP_STR:
                    StoreRegister(instr);
                    break;
                case Opcode.OP_NOT:
                    Not(instr);
                    break;
                case Opcode.OP_LDI:
                    LoadIndirect(instr);
                    break;
                case Opcode.OP_STI:
                    StoreIndirect(instr);
                    break;
                case Opcode.OP_JMP:
                    Jump(instr);
                    break;
                case Opcode.OP_LEA:
                    LoadEffectiveAddr(instr);
                    break;
                case Opcode.OP_TRAP:
                    Trap(instr);
                    break;
                case Opcode.OP_RTI:
                    ReturnFromInterrupt();
                    break;

                case Opcode.OP_RES:
                default:
                    Exception((byte)LC3VM.Exception.IllegalOpcode);
                    break;
            }
        }

        public bool Interrupt(byte vector, byte priority)
        {
            if (priority > 7)
                throw new ArgumentOutOfRangeException(nameof(priority), "Priority must not be > 7");
            if (priority <= Registers.PriorityLevel)
                return false;
            if (vector > 128)
                throw new ArgumentOutOfRangeException(nameof(vector), "Interrupt vector must be <= 128");

            EnterSupervisor(priority);
            PC = Memory[0x0180 + vector];

            return true;
        }

        private void Exception(byte vector)
        {
            if (vector > 128)
                throw new ArgumentOutOfRangeException(nameof(vector), "Exception vector must be <= 128");

            EnterSupervisor(Registers.PriorityLevel);
            PC = Memory[0x0180 + vector];
        }

        private void EnterSupervisor(byte priority)
        {
            // Save user state
            var pc = Registers[Register.PC];
            var psr = Registers[Register.PSR];

            // Swap into supervisor mode
            Registers.IsSupervisorMode = true;
            Registers.PriorityLevel = priority;
            Registers.Condition = Condition.None;

            // Save state on supervisor stack
            Push(psr);
            Push(pc);
        }

        #region instructions
        private void And(ushort instr)
        {
            var dr = (instr >> 9) & 0b111;
            var sr1 = (instr >> 6) & 0b111;
            var flag = (instr >> 5) & 0b1;

            if (flag == 0)
            {
                var sr2 = instr & 0b111;
                Registers[dr] = unchecked((ushort)(Registers[sr1] & Registers[sr2]));
            }
            else
            {
                var imm = unchecked((ushort)SignExtend(instr, 5));
                Registers[dr] = unchecked((ushort)(Registers[sr1] & imm));
            }

            UpdateCondition((Register)dr);
        }

        private void Add(ushort instr)
        {
            // destination register (DR)
            var dr = (instr >> 9) & 0b111;

            // first operand (SR1)
            var r1 = (instr >> 6) & 0b111;

            // whether we are in immediate mode
            var imm_flag = (instr >> 5) & 0b1;

            if (imm_flag != 0)
            {
                var imm5 = SignExtend(instr, 5);
                Registers[dr] = (ushort)(Registers[r1] + imm5);
            }
            else
            {
                var r2 = instr & 0b111;
                Registers[dr] = (ushort)(Registers[r1] + Registers[r2]);
            }

            UpdateCondition((Register)dr);
        }

        private void Not(ushort instr)
        {
            var dr = (instr >> 9) & 0b111;
            var sr = (instr >> 6) & 0b111;

            Registers[dr] = unchecked((ushort)~Registers[sr]);

            UpdateCondition((Register)dr);
        }


        private void JumpSubroutine(ushort instr)
        {
            var pc = Registers[Register.PC];
            Registers[Register.R7] = pc;

            if (((instr >> 11) & 0b1) == 0)
            {
                var baseR = (instr >> 6) & 0b111;
                Registers[Register.PC] = Registers[baseR];
            }
            else
            {
                var pc_offset = SignExtend(instr, 11);
                Registers[Register.PC] = unchecked((ushort)(pc + pc_offset));
            }
        }

        private void Branch(ushort instr)
        {
            var pc_offset = SignExtend(instr, 9);
            var cond_flag = (instr >> 9) & 0b111;

            if ((cond_flag & (int)Registers.Condition) != 0 || cond_flag == 0)
            {
                var v = unchecked((short)Registers[Register.PC]);
                Registers[Register.PC] = unchecked((ushort)(v + pc_offset));
            }
        }

        private void Jump(ushort instr)
        {
            var r1 = (instr >> 6) & 0b111;

            // Exit supervisor mode if this is a RET instruction and the final bit is set
            if (r1 == 7 & (instr & 0b1) == 1)
                Registers.IsSupervisorMode = false;

            Registers[Register.PC] = Registers[r1];
        }

        private void Trap(ushort instr)
        {
            var trap = instr & 0xFF;

            if (_traps.TryGetValue((ushort)trap, out var handler))
            {
                handler.Trap(this);
                return;
            }

            if (trap == (int)TrapCode.TRAP_HALT)
            {
                Halted = true;
                return;
            }

            // Save current position
            Registers[Register.R7] = Registers[Register.PC];

            // Jump to trap handler
            Registers[Register.PC] = ReadMemory(trap);

            //todo: this breaks 2048 (due to OS using RET instead of RTT/JMPT?)
            //// Enter supervision mode
            //IsSupervisorMode = true;
        }


        private void LoadEffectiveAddr(ushort instr)
        {
            var dr = (instr >> 9) & 0b111;
            var pc_offset = SignExtend(instr, 9);
            var pc = unchecked((short)Registers[Register.PC]);

            Registers[dr] = unchecked((ushort)(pc + pc_offset));

            UpdateCondition((Register)dr);
        }

        private void LoadRegister(ushort instr)
        {
            var dr = (instr >> 9) & 0b111;
            var br = (instr >> 6) & 0b111;
            var offset = SignExtend(instr, 6);

            var addr = ((short)Registers[br]) + offset;
            Registers[dr] = Memory[addr];

            UpdateCondition((Register)dr);
        }

        private void Load(ushort instr)
        {
            var r0 = (instr >> 9) & 0b111;
            var pc_offset = SignExtend(instr, 9);
            var pc = unchecked((short)Registers[Register.PC]);
            Registers[r0] = ReadMemory(pc + pc_offset);
            UpdateCondition((Register)r0);
        }

        private void LoadIndirect(ushort instr)
        {
            // destination register (DR) 
            var r0 = (instr >> 9) & 0b111;

            // PCoffset 9
            var pc_offset = SignExtend(instr, 9);

            // Determine actual address to read
            var pc = unchecked((short)Registers[Register.PC]);
            var addr = ReadMemory((ushort)(pc + pc_offset));

            // Read it
            Registers[r0] = ReadMemory(addr);

            UpdateCondition((Register)r0);
        }


        private void Store(ushort instr)
        {
            var sr = (instr >> 9) & 0b111;
            var offset = SignExtend(instr, 9);
            var addr = Registers[Register.PC] + offset;

            Memory[addr] = Registers[sr];
        }

        private void StoreRegister(ushort instr)
        {
            var sr = (instr >> 9) & 0b111;
            var br = (instr >> 6) & 0b111;

            var offset = SignExtend(instr, 6);

            WriteMemory(
                unchecked((short)Registers[br]) + offset,
                Registers[sr]
            );
        }

        private void StoreIndirect(ushort instr)
        {
            var r0 = (instr >> 9) & 0x7;
            var pc_offset = SignExtend(instr, 9);
            var pc = unchecked((short)Registers[Register.PC]);

            WriteMemory(
                ReadMemory(pc + pc_offset),
                Registers[r0]
            );
        }


        private void ReturnFromInterrupt()
        {
            if (!Registers.IsSupervisorMode)
            {
                Exception((byte)LC3VM.Exception.PrivelegeViolation);
                return;
            }

            // Pop state from supervisor stack
            var pc = Pop();
            var psr = Pop();

            // Restore state
            Registers[Register.PC] = pc;
            Registers[Register.PSR] = psr;
        }
        #endregion

        #region memory access
        private void WriteMemory(int addr, ushort data)
        {
            WriteMemory((ushort)addr, data);
        }

        private void WriteMemory(ushort addr, ushort data)
        {
            if (_memoryMap.TryGetValue(addr, out var device))
                device.Write(addr, data);
            else
                Memory[addr] = data;
        }

        private ushort ReadMemory(int addr)
        {
            return ReadMemory((ushort)addr);
        }

        private ushort ReadMemory(ushort addr)
        {
            if (_memoryMap.TryGetValue(addr, out var device))
                return device.Read(addr);
            return Memory[addr];
        }
        #endregion

        #region stack
        private void Push(ushort value)
        {
            Memory[Registers[Register.R6]] = value;
            Registers[Register.R6]++;
        }

        private ushort Pop()
        {
            Registers[Register.R6]--;
            return Memory[Registers[Register.R6]];
        }
        #endregion

        /// <summary>
        /// Take the last `bitCount` bits off x and sign extend
        /// </summary>
        /// <param name="x"></param>
        /// <param name="bitCount"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static short SignExtend(int x, int bitCount)
        {
            var mask = (1 << bitCount) - 1;
            var value = (x & mask);

            if (((value >> (bitCount - 1)) & 1) != 0)
                value |= (0xFFFF << bitCount);

            return unchecked((short)value);
        }

        private void UpdateCondition(Register register)
        {
            var value = Registers[(int)register];

            var flag = Condition.FL_POS;
            if ((value >> 15) != 0)
                flag = Condition.FL_NEG;
            else if (value == 0)
                flag = Condition.FL_ZRO;

            Registers.Condition = flag;
        }
    }
}