namespace AdventOfCode2023;

public class Day02 : IDay
{
    private const string file = @"inputs\day02.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    public long Run1()
    {
        Dictionary<string, int> maxValues = new()
        {
            ["red"] = 12,
            ["green"] = 13,
            ["blue"] = 14,
        };

        int result = 0;
        foreach (string line in input)
        {
            string[] tokens = line.Split(':');
            int index = int.Parse(tokens[0].Split().Last());

            bool isStopped = false;

            foreach (string game in tokens[1].Split(';'))
            {
                if (isStopped)
                {
                    break;
                }

                foreach (string item in game.Trim().Split(','))
                {
                    string[] itemTokens = item.Trim().Split();
                    int itemValue = int.Parse(itemTokens[0]);
                    string itemName = itemTokens[1];

                    if (itemValue > maxValues[itemName])
                    {
                        isStopped = true;
                        break;
                    }
                }
            }

            if (isStopped == false)
            {
                result += index;
            }
        }

        return result;
    }

    public long Run2()
    {
        int result = 0;
        foreach (string line in input)
        {
            Dictionary<string, int> maxValues = new()
            {
                ["red"] = 1,
                ["green"] = 1,
                ["blue"] = 1,
            };

            string[] tokens = line.Split(':');
            foreach (string game in tokens[1].Split(';'))
            {
                foreach (string item in game.Trim().Split(','))
                {
                    string[] itemTokens = item.Trim().Split();
                    int itemValue = int.Parse(itemTokens[0]);
                    string itemName = itemTokens[1];

                    if (itemValue > maxValues[itemName])
                    {
                        maxValues[itemName] = itemValue;
                    }
                }
            }

            int gamePower = 1;
            foreach (int value in maxValues.Values)
            {
                gamePower *= value;
            }

            result += gamePower;
        }

        return result;
    }
}
