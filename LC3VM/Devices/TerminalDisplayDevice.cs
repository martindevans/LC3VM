namespace LC3VM.Devices
{
    public class TerminalDisplayDevice
        : IMemoryMappedDevice
    {
        private const ushort DisplayStatus = 65028;
        private const ushort DisplayData = 65030;

        public IReadOnlyList<ushort> Addresses { get; } = new[] { DisplayStatus, DisplayData };

        public ushort Read(ushort addr)
        {
            switch (addr)
            {
                case DisplayStatus:
                    return 1 << 15;

                case DisplayData:
                    return 0;
            }

            throw new InvalidOperationException("Attempted to read memory mapped device out of range");
        }

        public void Write(ushort addr, ushort value)
        {
            if (addr == DisplayData)
            {
                var character = (char)((value << 8) >> 8);
                Console.Write(character);
            }
        }
    }
}
