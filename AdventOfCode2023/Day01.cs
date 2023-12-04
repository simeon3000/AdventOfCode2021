namespace AdventOfCode2023;

public class Day01 : IDay
{
    private const string file = @"inputs\day01.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    public long Run1()
    {
        char[] digits = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];

        int result = 0;
        foreach (string line in input)
        {
            int firstDigitIndex = line.IndexOfAny(digits);
            int lastDigitIndex = line.LastIndexOfAny(digits);

            int calibrationValue = int.Parse($"{line[firstDigitIndex]}{line[lastDigitIndex]}");

            result += calibrationValue;
        }

        return result;
    }

    public long Run2()
    {
        Dictionary<string, string> words = new()
        {
            ["1"] = "1",
            ["2"] = "2",
            ["3"] = "3",
            ["4"] = "4",
            ["5"] = "5",
            ["6"] = "6",
            ["7"] = "7",
            ["8"] = "8",
            ["9"] = "9",
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3",
            ["five"] = "5",
            ["four"] = "4",
            ["six"] = "6",
            ["seven"] = "7",
            ["eight"] = "8",
            ["nine"] = "9",
        };

        int result = 0;
        foreach (string line in input)
        {
            string workLine = line;
            string? firstDigit = null, lastDigit = null;

            while (firstDigit is null || lastDigit is null)
            {
                foreach (var word in words)
                {
                    if (firstDigit is null && workLine.StartsWith(word.Key))
                    {
                        firstDigit = word.Value;
                    }
                    if (lastDigit is null && workLine.EndsWith(word.Key))
                    {
                        lastDigit = word.Value;
                    }
                }

                if (firstDigit is null)
                {
                    workLine = workLine[1..];
                }
                if (lastDigit is null)
                {
                    workLine = workLine[..^1];
                }
            }

            int calibrationValue = int.Parse($"{firstDigit}{lastDigit}");

            result += calibrationValue;
        }

        return result;
    }
}
