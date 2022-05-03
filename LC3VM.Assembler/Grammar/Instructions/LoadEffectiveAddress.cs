using LC3VM.Registers;

namespace LC3VM.Assembler.Grammar.Instructions;

internal class LoadEffectiveAddress
    : BaseInstruction
{
    public Register DR { get; }
    public string SourceLabel { get; }

    public LoadEffectiveAddress(Register dr, string sourceLabel)
    {
        DR = dr;
        SourceLabel = sourceLabel;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        var offset9 = PCOffset9(pc, symbolTable[SourceLabel]);

        yield return (ushort)(((int)Opcode.OP_LEA << 12) | (byte)DR << 9 | offset9);
    }
}