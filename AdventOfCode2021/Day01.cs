using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day01 : IDay
    {
        private const string file = @"inputs\day01.txt";

        public long Run1()
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

            return counter;
        }

        public long Run2()
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

            return counter;
        }
    }
}
