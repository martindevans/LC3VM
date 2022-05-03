using CommandLine;
using LC3VM.Assembler;
using LC3VM.Assembler.Console;

var parsed = Parser.Default.ParseArguments<Options>(args);

parsed.WithNotParsed(errors =>
{
    foreach (var error in errors)
        Console.WriteLine(error);
});

parsed.WithParsed(o =>
{
    foreach (var path in o.Inputs)
        Assemble(path);
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