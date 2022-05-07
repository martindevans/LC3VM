namespace LC3VM.Assembler.Grammar.Instructions
{
    internal class JumpSubroutine
        : BaseInstruction
    {
        public ushort Offset { get; }

        public JumpSubroutine(ushort offset)
        {
            Offset = offset;
        }

        public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
        {
            yield return (ushort)(((int)Opcode.OP_JSR << 12) | 1 << 11 | Offset);
        }
    }
}
