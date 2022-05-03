namespace LC3VM.Traps
{
    internal enum TrapCode
    {
        /// <summary>
        /// get character from keyboard, not echoed onto the terminal
        /// </summary>
        TRAP_GETC = 32,

        /// <summary>
        /// output a character
        /// </summary>
        TRAP_OUT = 33,

        /// <summary>
        /// output a word string
        /// </summary>
        TRAP_PUTS = 34,

        /// <summary>
        /// get character from keyboard, echoed onto the terminal
        /// </summary>
        TRAP_IN = 35,

        /// <summary>
        /// output a byte string
        /// </summary>
        TRAP_PUTSP = 36,

        /// <summary>
        /// halt the program
        /// </summary>
        TRAP_HALT = 37
    }
}
