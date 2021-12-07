using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    public class Helper
    {
        public static List<string> GetInputLines(string file)
        {
            List<string> input = new();
            foreach (string line in File.ReadLines(file))
            {
                input.Add(line);
            }

            return input;
        }

        public static void PrintResult(IDay day, string run, long result)
        {
            System.Console.WriteLine($"{day.GetType().Name} {run} -> Result: {result}");
        }
    }
}
