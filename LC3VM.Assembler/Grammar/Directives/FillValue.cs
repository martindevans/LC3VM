namespace LC3VM.Assembler.Grammar.Directives;

internal class FillValue
    : BaseDirective
{
    public ushort Value { get; }

    public override ushort Length => 1;

    public FillValue(ushort value)
    {
        Value = value;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        yield return Value;
    }
}