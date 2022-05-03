namespace LC3VM.Assembler.Grammar.Instructions;

internal abstract class BaseInstruction
    : BaseLine
{
    public override string? Label => null;

    public override ushort Length => 1;

    protected int PCOffset9(int pc, ushort addr)
    {
        var signedOffset = addr - pc - 1;
        if (signedOffset < -256 || signedOffset > 255)
            throw new InvalidOperationException("PCOffset9 is too large");

        return signedOffset & 0b1_1111_1111;
    }
}