namespace LC3VM.Assembler.Grammar.Directives;

internal class FillLabel
    : BaseDirective
{
    public string FillFromLabel { get; }

    public override ushort Length => 1;

    public FillLabel(string label)
    {
        FillFromLabel = label;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        yield return symbolTable[FillFromLabel];
    }
}