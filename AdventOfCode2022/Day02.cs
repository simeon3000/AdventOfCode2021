namespace AdventOfCode2022;

public class Day02 : IDay
{
    private const string file = @"inputs\day02.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    public long Run1()
    {
        Dictionary<string, int> scores = new()
        {
            ["A X"] = 4,
            ["A Y"] = 8,
            ["A Z"] = 3,
            ["B X"] = 1,
            ["B Y"] = 5,
            ["B Z"] = 9,
            ["C X"] = 7,
            ["C Y"] = 2,
            ["C Z"] = 6,
        };

        return GetSum(scores);
    }

    public long Run2()
    {
        Dictionary<string, int> scores = new()
        {
            ["A X"] = 3,
            ["A Y"] = 4,
            ["A Z"] = 8,
            ["B X"] = 1,
            ["B Y"] = 5,
            ["B Z"] = 9,
            ["C X"] = 2,
            ["C Y"] = 6,
            ["C Z"] = 7,
        };

        return GetSum(scores);
    }

    private static int GetSum(Dictionary<string, int> scores)
    {
        int sum = 0;
        input.ForEach(x => sum += scores[x]);

        return sum;
    }
}
