using System.Text.RegularExpressions;

namespace AdventOfCode2022;

public partial class Day06 : IDay
{
    private const string file = @"inputs\day06.txt";
    private static readonly string input = Helper.GetInputLines(file).First();

    [GeneratedRegex("^(?!.*(.).*\\1)[a-z]+$")]
    private static partial Regex NonRepeatableChar();

    public long Run1() => GetIndex(4);
    
    public long Run2() => GetIndex(14);

    private static int GetIndex(int markerLength)
    {
        for (int i = 0; i <= input.Length - markerLength; i++)
        {
            int endIndex = i + markerLength;
            string marker = input[i..endIndex];
            if (NonRepeatableChar().IsMatch(marker))
            {
                return endIndex;
            }
        }

        return -1;
    }    
}
