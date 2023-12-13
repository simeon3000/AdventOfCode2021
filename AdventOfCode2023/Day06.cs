namespace AdventOfCode2023;

public class Day06 : IDay
{
    private const string file = @"inputs\day06.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    private static readonly List<int> times =
        input[0].Split(':').TakeLast(1).First().Trim()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    private static readonly List<int> records =
        input[1].Split(':').TakeLast(1).First().Trim()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

    public long Run1()
    {
        long result = 1;

        for (int i = 0; i < times.Count; i++)
        {
            int raceTime = times[i];
            int recordDistance = records[i];

            int recordCounter = 0;
            for (int j = 0; j <= raceTime; j++)
            {
                int currentSpeed = j;
                int currentDistance = currentSpeed * (raceTime - j);

                if (currentDistance > recordDistance)
                {
                    recordCounter++;
                }
            }

            result *= recordCounter;
        }

        return result;
    }

    public long Run2()
    {
        string timeString = "";
        string distanceString = "";
        for (int i = 0; i < times.Count; i++)
        {
            timeString += times[i].ToString();
            distanceString += records[i].ToString();
        }

        long raceTime = long.Parse(timeString);
        long recordDistance = long.Parse(distanceString);

        long recordCounter = 0;
        for (int j = 0; j <= raceTime; j++)
        {
            long currentSpeed = j;
            long currentDistance = currentSpeed * (raceTime - j);

            if (currentDistance > recordDistance)
            {
                recordCounter++;
            }
        }

        return recordCounter;
    }
}
