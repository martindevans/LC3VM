using Pegasus.Common;

namespace LC3VM.Assembler.Grammar
{
    public class ParseException
        : Exception
    {
        public Cursor Cursor { get; }

        public ParseException(Cursor cursor, string message)
            : base(message)
        {
            Cursor = cursor;
        }
    }
}
