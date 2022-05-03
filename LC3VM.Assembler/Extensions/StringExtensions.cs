namespace LC3VM.Assembler.Extensions;

internal static class StringExtensions
{
    public static string TrimStart(this string target, string trimString)
    {
        if (string.IsNullOrEmpty(trimString))
            return target;

        var result = target.AsSpan();
        while (result.StartsWith(trimString))
            result = result[trimString.Length..];

        return result.ToString();
    }
}