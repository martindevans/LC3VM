namespace LC3VM.Assembler.Grammar.Directives;

internal class FillString
    : BaseDirective
{
    public string Value { get; }

    public override ushort Length => (ushort)(Value.Length + 1);

    public FillString(string value)
    {
        Value = value;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        foreach (var character in Value)
            yield return character;
        yield return 0;
    }
}