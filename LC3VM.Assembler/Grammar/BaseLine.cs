namespace LC3VM.Assembler.Grammar;

internal abstract class BaseLine
{
    public abstract string? Label { get; }

    public abstract ushort Length { get; }

    public abstract IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc);
}