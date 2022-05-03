namespace LC3VM.Assembler.Grammar.Directives;

internal class Origin
    : BaseDirective
{
    public ushort Value { get; }

    public override ushort Length => Value;

    public Origin(ushort value)
    {
        Value = value;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        yield return Value;
    }
}