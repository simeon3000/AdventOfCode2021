using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day1
    {
        private const string file = @"c:\temp\day1.txt";
        public static void Run1()
        {
            int prev = int.MaxValue;
            int counter = 0;

            foreach (string line in File.ReadLines(file))
            {
                int current = int.Parse(line);

                if (current > prev)
                {
                    counter++;
                }

                prev = current;
            }

            Console.WriteLine($"Day 1 Run1 -> Counter: {counter}");
        }

        public static void Run2()
        {
            var values = new List<int>();            
            foreach (string line in File.ReadLines(file))
            {                
                values.Add(int.Parse(line));                
            }

            int counter = 0;
            int prevSum = int.MaxValue;

            for (int i = 0; i < values.Count - 2; i++)
            {
                int sum = values.Skip(i).Take(3).Sum();

                if (sum > prevSum)
                {
                    counter++;
                }

                prevSum = sum;
            }

            Console.WriteLine($"Day 1 Run2 -> Counter: {counter}");
        }
    }
}
