using LC3VM.Registers;

namespace LC3VM.Assembler.Grammar.Instructions;

internal class JumpInstruction
    : BaseInstruction
{
    public Register BR { get; }
    public bool ExitSupervisor { get; }

    public JumpInstruction(Register br, bool exitSupervisor = false)
    {
        BR = br;
        ExitSupervisor = exitSupervisor;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        yield return (ushort)(((int)Opcode.OP_JMP << 12) | (byte)BR << 6 | (ExitSupervisor ? 1 : 0));
    }
}