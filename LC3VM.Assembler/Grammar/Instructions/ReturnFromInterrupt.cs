namespace LC3VM.Assembler.Grammar.Instructions;

internal class ReturnFromInterrupt
    : BaseInstruction
{
    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        yield return (int)Opcode.OP_RTI << 12;
    }
}