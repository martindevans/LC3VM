using LC3VM.Registers;

namespace LC3VM.Assembler.Grammar.Instructions
{
    internal class JumpSubroutineRegister
        : BaseInstruction
    {
        public Register Destination { get; }

        public JumpSubroutineRegister(Register destination)
        {
            Destination = destination;
        }

        public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
        {
            yield return (ushort)(((int)Opcode.OP_JSR << 12) | (int)Destination << 6);
        }
    }
}
