namespace LC3VM.Assembler.Grammar;

internal class LabelledLine
    : BaseLine
{
    public override string Label { get; }
    public BaseLine? Line { get; }

    public override ushort Length => Line?.Length ?? 0;

    public LabelledLine(string label, BaseLine? line)
    {
        Label = label;
        Line = line;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        return Line?.Emit(symbolTable, pc) ?? Array.Empty<ushort>();
    }
}