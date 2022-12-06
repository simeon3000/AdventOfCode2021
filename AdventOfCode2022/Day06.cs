using System.Text.RegularExpressions;

namespace AdventOfCode2022;

public class Day06 : IDay
{
    private const string file = @"inputs\day06.txt";
    private static readonly string input = Helper.GetInputLines(file).First();

    private const string pattern = @"^(?!.*(.).*\1)[a-z]+$";

    public long Run1() => GetIndex(4);
    
    public long Run2() => GetIndex(14);

    private int GetIndex(int markerLength)
    {
        for (int i = 0; i <= input.Length - markerLength; i++)
        {
            int endIndex = i + markerLength;
            string marker = input[i..endIndex];
            if (Regex.IsMatch(marker, pattern))
            {
                return endIndex;
            }
        }

        return -1;
    }
}
