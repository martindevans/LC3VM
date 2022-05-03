using CommandLine;

namespace LC3VM.Assembler.Console;

public class Options
{
    [Option('a', "assemble", Required = true, HelpText = "Assemble a file, or a list of files, into obj file(s)")]
    public IEnumerable<string> Inputs { get; set; } = null!;
}