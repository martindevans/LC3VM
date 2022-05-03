namespace LC3VM.Devices
{
    public interface IMemoryMappedDevice
        : IMachineExtension
    {
        IReadOnlyList<ushort> Addresses { get; }

        ushort Read(ushort addr);

        void Write(ushort addr, ushort value);
    }
}
