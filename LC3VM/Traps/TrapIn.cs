using LC3VM.Registers;

namespace LC3VM.Traps
{
    public class TrapIn
        : ITrapHandler
    {
        public ushort TrapId => (ushort)TrapCode.TRAP_IN;

        public void Trap(VM state)
        {
            Console.WriteLine();
            Console.Write(">");
            state.Registers[(int)Register.R0] = Console.ReadKey(false).KeyChar;
        }
    }
}
