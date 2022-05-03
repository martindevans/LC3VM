using System.Text;
using LC3VM.Assembler.Grammar;
using LC3VM.Assembler.Grammar.Directives;
using Pegasus.Common;

namespace LC3VM.Assembler;

public class Assembler
{
    private readonly List<ushort> _outputs = new List<ushort>();
    private readonly Dictionary<string, ushort> _symbolTable = new Dictionary<string, ushort>();

    public void Assemble(Stream inputStream)
    {
        // Parse the source code
        var ast = Parse(new StreamReader(inputStream).ReadToEnd());
        if (ast.Lines[0] is not Origin)
            throw new InvalidOperationException("First line must be .ORIG");

        // Generate symbol table
        var offset = (ushort)0;
        foreach (var line in ast.Lines)
        {
            if (line.Label != null)
                _symbolTable.Add(line.Label, offset);
            offset += line.Length;
        }

        // Output result
        var pc = 0;
        foreach (var line in ast.Lines)
        {
            _outputs.AddRange(line.Emit(_symbolTable, pc).ToArray());
            pc += line.Length;
        }
    }

    private static Program Parse(string input)
    {
        try
        {
            return new AssemblerParser().Parse(input);
        }
        catch (FormatException ex)
        {
            var cursor = ex.Data["cursor"] as Cursor;
            throw;
        }
    }

    public void Write(Stream output)
    {
        using var writer = new BinaryWriter(output, Encoding.ASCII, true);
        foreach (var @ushort in _outputs)
            writer.Write(Swap16(@ushort));

        static ushort Swap16(ushort x)
        {
            var b = BitConverter.GetBytes(x);
            return checked((ushort)((b[0] << 8) | b[1]));
        }
    }
}