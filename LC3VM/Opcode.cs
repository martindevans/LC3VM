namespace LC3VM
{
    public enum Opcode
    {
        OP_BR,     /* branch */
        OP_ADD,    /* add  */
        OP_LD,     /* load */
        OP_ST,     /* store */
        OP_JSR,    /* jump register */
        OP_AND,    /* bitwise and */
        OP_LDR,    /* load register */
        OP_STR,    /* store register */
        OP_RTI,    /* unused */
        OP_NOT,    /* bitwise not */
        OP_LDI,    /* load indirect */
        OP_STI,    /* store indirect */
        OP_JMP,    /* jump */
        OP_RES,    /* reserved (unused) */

        /// <summary>
        /// Load Effective Address
        /// </summary>
        OP_LEA,

        /// <summary>
        /// Execute trap code
        /// </summary>
        OP_TRAP
    }
}
