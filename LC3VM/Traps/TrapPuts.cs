using LC3VM.Registers;

namespace LC3VM.Traps
{
    public class TrapPuts
        : ITrapHandler
    {
        public ushort TrapId => (ushort)TrapCode.TRAP_PUTS;

        public void Trap(VM state)
        {
            var index = state.Registers[(int)Register.R0];
            while (state.Memory[index] != 0)
            {
                Console.Write((char)state.Memory[index]);
                index++;
            }
        }
    }
}
