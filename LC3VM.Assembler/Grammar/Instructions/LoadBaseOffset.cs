using LC3VM.Registers;

namespace LC3VM.Assembler.Grammar.Instructions;

internal class LoadBaseOffset
    : BaseInstruction
{
    public Register DR { get; }
    public Register BR { get; }
    public byte Offset { get; }

    public LoadBaseOffset(Register dr, Register br, byte offset)
    {
        if (Offset > 31)
            throw new ArgumentOutOfRangeException(nameof(offset), "LDR ofset must be < 32");

        DR = dr;
        BR = br;
        Offset = offset;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        yield return (ushort)(((int)Opcode.OP_LDR << 12) | (byte)DR << 9 | (byte)BR << 6 | Offset);
    }
}