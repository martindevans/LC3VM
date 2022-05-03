namespace LC3VM.Assembler.Grammar;

internal class Program
{
    public IReadOnlyList<BaseLine> Lines { get; }

    public Program(IEnumerable<BaseLine?> lines)
    {
        Lines = lines
            .Where(l => l != null)
            .Cast<BaseLine>()
            .ToList();
    }
}