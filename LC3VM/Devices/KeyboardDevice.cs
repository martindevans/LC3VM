namespace LC3VM.Devices
{
    public class KeyboardDevice
        : IMemoryMappedDevice
    {
        private const ushort KeyboardStatus = 0xFE00;
        private const ushort KeyboardData   = 0xFE02;

        public IReadOnlyList<ushort> Addresses { get; } = new[] { KeyboardStatus, KeyboardData };

        private ushort _status;
        private char _keyChar;

        public ushort Read(ushort addr)
        {
            switch (addr)
            {
                case KeyboardStatus when Console.KeyAvailable:
                    _keyChar = Console.ReadKey(true).KeyChar;
                    return (ushort)((1 << 15) | _status);

                case KeyboardStatus:
                    return _status;

                case KeyboardData:
                    return _keyChar;
            }

            throw new InvalidOperationException("Attempted to read memory mapped device out of range");
        }

        public void Write(ushort addr, ushort value)
        {
            // If writing to status address preserve all the bits except the 15th
            if (addr == KeyboardStatus)
                _status = (ushort)(value & 0x7FFF);
        }
    }
}
