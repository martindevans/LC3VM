using LC3VM.Registers;

namespace LC3VM.Assembler.Grammar.Instructions;

internal class Store
    : BaseInstruction
{
    public Register SR { get; }
    public string DestLabel { get; }

    public Store(Register sr, string destLabel)
    {
        SR = sr;
        DestLabel = destLabel;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        var offset9 = PCOffset9(pc, symbolTable[DestLabel]);

        yield return (ushort)(((int)Opcode.OP_ST << 12) | (byte)SR << 9 | offset9);
    }
}