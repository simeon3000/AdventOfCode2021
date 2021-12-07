using System.IO;

namespace AdventOfCode2021
{
    public class Day02 : IDay
    {
        private const string file = @"inputs\day02.txt";

        public long Run1()
        {
            int distance = 0,
                depth = 0;

            foreach (string line in File.ReadLines(file))
            {                
                GetCommandAndValue(line, out string command, out int value);

                switch (command)
                {
                    case "forward":
                        distance += value;
                        break;
                    case "down":
                        depth += value;
                        break;
                    case "up":
                        depth -= value;
                        break;
                    default:
                        break;
                }
            }

            long result = distance * depth;
            return result;
        }        

        public long Run2()
        {
            int distance = 0,
                depth = 0,
                aim = 0;

            foreach (string line in File.ReadLines(file))
            {
                GetCommandAndValue(line, out string command, out int value);

                switch (command)
                {
                    case "forward":
                        distance += value;
                        depth += value * aim;
                        break;
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    default:
                        break;
                }
            }

            long result = distance * depth;
            return result;
        }

        private static void GetCommandAndValue(string line, out string command, out int value)
        {
            string[] tokens = line.Split();
            command = tokens[0];
            value = int.Parse(tokens[1]);
        }
    }
}
