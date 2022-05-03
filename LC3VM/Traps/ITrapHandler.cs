namespace LC3VM.Traps
{
    public interface ITrapHandler
        : IMachineExtension
    {
        public ushort TrapId { get; }

        public void Trap(VM state);
    }
}
