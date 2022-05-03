using LC3VM.Registers;

namespace LC3VM.Assembler.Grammar.Instructions;

internal class Add
    : BaseInstruction
{
    public Register DR { get; }
    public Register SR1 { get; }
    public Register SR2 { get; }

    public Add(Register dr, Register sr1, Register sr2)
    {
        DR = dr;
        SR1 = sr1;
        SR2 = sr2;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        yield return (ushort)(((int)Opcode.OP_ADD << 12) | (byte)DR << 9 | (byte)SR1 << 6 | (byte)SR2);
    }
}