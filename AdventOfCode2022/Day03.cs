namespace AdventOfCode2022;

public class Day03 : IDay
{
    private const string file = @"inputs\day03.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    public long Run1()
    {
        int sum = 0;
        foreach (string line in input)
        {
            int index = line.Length / 2;
            string firstHalf = line[..index];
            string secondHalf = line[index..];

            char c = firstHalf.Intersect(secondHalf).First();
            sum += GetCharValue(c);
        }
       
        return sum;
    }

    public long Run2()
    {
        int cnt = 0, sum = 0;
        string s1 = "", s2 = "", s3 = "";
        foreach (string line in input)
        {
            cnt++;
            if (cnt == 1)
            {
                s1 = line;
            }
            else if (cnt == 2)
            {
                s2 = line;
            }
            else
            {
                s3 = line;
                char c = s1.Intersect(s2).Intersect(s3).First();
                sum += GetCharValue(c);

                cnt = 0;
            }
        }
        
        return sum;
    }
    
    //a to z -> 1 to 26; A to Z -> 27 to 52   
    private static int GetCharValue(char c) => char.IsUpper(c) ? c - 64 + 26 : c - 96;
}
