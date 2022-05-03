﻿using LC3VM.Registers;

namespace LC3VM.Assembler.Grammar.Instructions;

internal class AndImmediate
    : BaseInstruction
{
    public Register DR { get; }
    public Register SR1 { get; }
    public byte Immediate { get; }

    public AndImmediate(Register dr, Register sr1, byte imm)
    {
        if (imm > 31)
            throw new ArgumentOutOfRangeException(nameof(imm), "AND imm must be < 32");

        DR = dr;
        SR1 = sr1;
        Immediate = imm;
    }

    public override IEnumerable<ushort> Emit(IReadOnlyDictionary<string, ushort> symbolTable, int pc)
    {
        yield return (ushort)(((int)Opcode.OP_AND << 12) | (byte)DR << 9 | (byte)SR1 << 6 | 0b100000 | Immediate);
    }
}