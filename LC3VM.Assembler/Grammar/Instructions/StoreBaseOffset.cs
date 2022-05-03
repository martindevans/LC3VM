using LC3VM.Registers;

namespace LC3VM.Assembler.Grammar.Instructions;

internal class StoreBaseOffset
    : BaseInstruction
{
    public Register SR { get; }
    public Register BR { get; }
    public byte Offset { get; }

    public StoreBaseOffset(Register sr, Register br, byte offset)
    {
        if (Offset > 64)
            throw new ArgumentOutOfRangeException(nameof(offset), "STR Offset must be <= 64");

        SR = sr;
        BR = br;
        Offset = offset;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        yield return (ushort)(((int)Opcode.OP_STR << 12) | ((byte)SR) << 9 | ((byte)BR) << 6 | Offset);
    }
}