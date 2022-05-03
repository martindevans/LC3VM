using LC3VM.Registers;

namespace LC3VM.Traps
{
    public class TrapGetC
        : ITrapHandler
    {
        public ushort TrapId => (ushort)TrapCode.TRAP_GETC;

        public void Trap(VM state)
        {
            state.Registers[(int)Register.R0] = Console.ReadKey(true).KeyChar;
        }
    }
}
