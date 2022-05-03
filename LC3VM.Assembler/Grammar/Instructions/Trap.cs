namespace LC3VM.Assembler.Grammar.Instructions;

internal class Trap
    : BaseInstruction
{
    public byte Code { get; }

    public Trap(byte code)
    {
        Code = code;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        yield return (ushort)(0b1111_0000_0000_0000 | Code);
    }
}