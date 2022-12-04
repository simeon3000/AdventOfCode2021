namespace AdventOfCode2022;

public class Day04 : IDay
{
    private const string file = @"inputs\day04.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    private int start1, start2, end1, end2;

    public long Run1()
    {
        int sum = 0;
        foreach (string line in input)
        {
            GetBorders(line);
            //full overlap
            if ((start1 >= start2 && end1 <= end2) || (start2 >= start1 && end2 <= end1))
            {
                sum++;
            }
        }

        return sum;
    }

    public long Run2()
    {
        int sum = 0;
        foreach (string line in input)
        {
            GetBorders(line);
            //partial overlap
            if ((start1 >= start2 || end1 >= start2) && (start2 >= start1 || end2 >= start1))
            {
                sum++;
            }
        }

        return sum;
    }

    private void GetBorders(string line)
    {
        string[] pairs = line.Split(',');
        start1 = int.Parse(pairs.First().Split('-').First());
        end1 = int.Parse(pairs.First().Split('-').Last());
        start2 = int.Parse(pairs.Last().Split('-').First());
        end2 = int.Parse(pairs.Last().Split('-').Last());
    }
}
