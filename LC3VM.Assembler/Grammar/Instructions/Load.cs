using LC3VM.Registers;

namespace LC3VM.Assembler.Grammar.Instructions;

internal class Load
    : BaseInstruction
{
    public Register DR { get; }
    public string SourceLabel { get; }

    public Load(Register dr, string srcLabel)
    {
        DR = dr;
        SourceLabel = srcLabel;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        var offset9 = PCOffset9(pc, symbolTable[SourceLabel]);

        yield return (ushort)(((int)Opcode.OP_LD << 12) | (byte)DR << 9 | offset9);
    }
}