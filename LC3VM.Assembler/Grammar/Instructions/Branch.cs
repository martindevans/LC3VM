namespace LC3VM.Assembler.Grammar.Instructions;

internal class Branch
    : BaseInstruction
{
    public string DestLabel { get; }
    public bool N { get; }
    public bool Z { get; }
    public bool P { get; }

    public Branch(string destLabel, bool n, bool z, bool p)
    {
        DestLabel = destLabel;
        N = n;
        Z = z;
        P = p;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        var offset9 = PCOffset9(pc, symbolTable[DestLabel]);

        yield return (ushort)(
              0
            | ((N ? 1 : 0) << 11)
            | ((Z ? 1 : 0) << 10)
            | ((P ? 1 : 0) << 9)
            | offset9
        );
    }
}