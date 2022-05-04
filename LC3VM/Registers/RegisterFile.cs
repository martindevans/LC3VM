namespace LC3VM.Registers
{
    public class RegisterFile
    {
        private readonly ushort[] _registers;
        private ushort _ssp = 0x2FFF;
        private ushort _usp = 0xFDFF;

        public ref ushort this[Register idx] => ref _registers[(int)idx];

        public ref ushort this[int idx]
        {
            get
            {
                if (idx < 0 || idx > _registers.Length)
                    throw new ArgumentOutOfRangeException(nameof(idx));

                // Swap in the User/Supervisor stack pointer as necessary
                if (idx == (int)Register.R6)
                {
                    if (IsSupervisorMode)
                        return ref _ssp;
                    return ref _usp;
                }

                return ref _registers[idx];
            }
        }

        internal Condition Condition
        {
            get => (Condition)(this[Register.PSR] & 0b111);
            set => this[Register.PSR] = (ushort)((this[Register.PSR] & ~0b111) | (ushort)value);
        }
        internal bool IsSupervisorMode
        {
            get => (this[Register.PSR] & (1 << 15)) == 0;
            set => this[Register.PSR] = (ushort)((this[Register.PSR] & 0x7FFF) | ((value ? 0 : 1) << 15));
        }
        internal byte PriorityLevel
        {
            get => (byte)((this[Register.PSR] >> 8) & 0b111);
            set
            {
                if (value > 7)
                    throw new ArgumentOutOfRangeException(nameof(value), "Priority must not be > 7");
                this[Register.PSR] = (ushort)((this[Register.PSR] & 0xF8FF) | (value << 8));
            }
        }

        internal RegisterFile()
        {
            _registers = new ushort[(int)Register.COUNT];
        }
    }
}
