namespace LC3VM.Registers
{
    public class RegisterFile
    {
        private readonly ushort[] _registers;

        public ref ushort this[Register idx] => ref _registers[(int)idx];

        public ref ushort this[int idx]
        {
            get
            {
                if (idx < 0 || idx > _registers.Length)
                    throw new ArgumentOutOfRangeException(nameof(idx));
                return ref _registers[idx];
            }
        } 

        internal RegisterFile(ushort[] registers)
        {
            _registers = registers;
        }
    }
}
