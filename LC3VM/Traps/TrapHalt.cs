namespace LC3VM.Traps
{
    public class TrapHalt
        : ITrapHandler
    {
        public ushort TrapId => (ushort)TrapCode.TRAP_HALT;

        public void Trap(VM state)
        {
            state.Halted = true;
        }
    }
}
