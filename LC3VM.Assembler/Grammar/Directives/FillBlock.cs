namespace LC3VM.Assembler.Grammar.Directives;

internal class FillBlock
    : BaseDirective
{
    public override ushort Length { get; }
    public ushort Value { get; }

    public FillBlock(ushort length, ushort value)
    {
        Length = length;
        Value = value;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        for (var i = 0; i < Length; i++)
            yield return Value;
    }
}