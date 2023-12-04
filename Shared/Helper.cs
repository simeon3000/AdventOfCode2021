using System.Collections.Generic;
using System.IO;

namespace Shared;

public class Helper
{
    public static List<string> GetInputLines(string file)
    {
        List<string> input = [.. File.ReadLines(file)];

        return input;
    }

    public static void PrintResult(IDay day, string run, long result)
    {
        System.Console.WriteLine($"{day.GetType().Name} {run} -> Result: {result}");
    }
}
