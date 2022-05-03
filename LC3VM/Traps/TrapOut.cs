using LC3VM.Registers;

namespace LC3VM.Traps
{
    public class TrapOut
        : ITrapHandler
    {
        public ushort TrapId => (ushort)TrapCode.TRAP_OUT;

        public void Trap(VM state)
        {
            Console.Write((char)state.Registers[(int)Register.R0]);
        }
    }
}
