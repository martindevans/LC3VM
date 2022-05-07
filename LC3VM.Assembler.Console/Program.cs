using CommandLine;
using LC3VM.Assembler;
using LC3VM.Assembler.Console;
using LC3VM.Assembler.Grammar;

var parsed = Parser.Default.ParseArguments<Options>(args);

parsed.WithNotParsed(errors =>
{
    foreach (var error in errors)
        Console.WriteLine(error);
});

parsed.WithParsed(o =>
{
    foreach (var path in o.Inputs)
    {
        try
        {
            Assemble(path);
        }
        catch (ParseException ex)
        {
            var cursor = ex.Cursor;

            var spaces = new string(' ', Math.Max(0, cursor.Column - 2));

            var lines = cursor.Subject.Split(new string[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
            var line = lines[cursor.Line - 1];

            Console.WriteLine($" ## {path}");
            Console.WriteLine(
                $"{line}\n"
              + $"{spaces}^ {ex.Message} (Ln{cursor.Line}, Col{cursor.Column - 1})\n"
            );
        }
    }
});

void Assemble(string path)
{
    // Setup input file
    var inputFile = new FileInfo(path);
    using var inputStream = inputFile.OpenRead();
    
    // Assemble into memory
    var assembler = new Assembler();
    assembler.Assemble(inputStream);

    // Create output file
    var extLength = inputFile.Extension.Length;
    var outPath = Path.Combine(inputFile.Directory?.FullName ?? "", $"{inputFile.Name[..^extLength]}.obj");
    using var output = File.OpenWrite(outPath);
    assembler.Write(output);
}