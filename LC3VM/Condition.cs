namespace LC3VM
{
    [Flags]
    internal enum Condition
        : short
    {
        None,

        FL_POS = 1, /* P */
        FL_ZRO = 2, /* Z */
        FL_NEG = 4, /* N */
    }
}
