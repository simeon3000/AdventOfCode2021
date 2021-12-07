using System;
using System.IO;

namespace AdventOfCode2021
{
    public class Day2
    {
        private const string file = @"c:\temp\day2.txt";
        public static void Run1()
        {
            int distance = 0;
            int depth = 0;

            foreach (string line in File.ReadLines(file))
            {
                string[] tokens = line.Split();
                string command = tokens[0];
                int value = int.Parse(tokens[1]);

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
            Console.WriteLine($"Day 2 Run1 -> Result: {result}");
        }

        public static void Run2()
        {
            int distance = 0;
            int depth = 0;
            int aim = 0;

            foreach (string line in File.ReadLines(file))
            {
                string[] tokens = line.Split();
                string command = tokens[0];
                int value = int.Parse(tokens[1]);

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
            Console.WriteLine($"Day 2 Run2 -> Result: {result}");
        }
    }
}
