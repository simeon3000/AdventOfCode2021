using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    public class Helper
    {
        public static List<string> GetInput(string file)
        {
            var input = new List<string>();
            foreach (string line in File.ReadLines(file))
            {
                input.Add(line);
            }

            return input;
        }
    }
}
