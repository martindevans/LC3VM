using System.Runtime.InteropServices;

namespace LC3VM.Registers
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct PSR
    {
        [FieldOffset(0)]
        public ushort RawValue;

        public int PriorityLevel => (RawValue >> 8) & 0b111;

        public bool IsPriveleged => (RawValue & (1 << 15)) == 0;

        public Condition Condition => (Condition)(RawValue & 0b111);
    }
}
