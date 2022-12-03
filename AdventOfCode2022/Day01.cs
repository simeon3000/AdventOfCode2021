namespace AdventOfCode2022;

public class Day01 : IDay
{
    private const string file = @"inputs\day01.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    public long Run1()
    {
        int maxSum = 0, currentSum = 0;
        foreach (string item in input)
        {
            if (string.IsNullOrEmpty(item))
            {
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }

                currentSum = 0;
                continue;
            }

            currentSum += int.Parse(item);
        }

        return maxSum > currentSum ? maxSum : currentSum;
    }

    public long Run2()
    {
        List<int> elves = new();
        int currentSum = 0;
        foreach (string item in input)
        {
            if (!string.IsNullOrEmpty(item))
            {
                currentSum += int.Parse(item);
                continue;
            }

            elves.Add(currentSum);
            currentSum = 0;
        }

        elves.Add(currentSum);
        return elves.OrderByDescending(x => x).Take(3).Sum();
    }
}
