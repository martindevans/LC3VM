using LC3VM.Registers;

namespace LC3VM.Assembler.Grammar.Instructions;

internal class LoadIndirect
    : BaseInstruction
{
    public Register DR { get; }
    public string SrcLabel { get; }

    public LoadIndirect(Register dr, string label)
    {
        DR = dr;
        SrcLabel = label;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        var offset9 = PCOffset9(pc, symbolTable[SrcLabel]);

        yield return (ushort)(((int)Opcode.OP_LDI << 12) | ((byte)DR) << 9 | offset9);
    }
}