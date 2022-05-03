using LC3VM.Registers;

namespace LC3VM.Assembler.Grammar.Instructions;

internal class StoreIndirect
    : BaseInstruction
{
    public Register SR { get; }
    public string DestLabel { get; }

    public StoreIndirect(Register sr, string label)
    {
        SR = sr;
        DestLabel = label;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        var offset9 = PCOffset9(pc, symbolTable[DestLabel]);

        yield return (ushort)(((int)Opcode.OP_STI << 12) | ((byte)SR) << 9 | offset9);
    }
}