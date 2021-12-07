using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day7
    {
        private const string file = @"c:\temp\day7.txt";        
        private static readonly List<string> input;

        static Day7()
        {
            input = Helper.GetInputLines(file);
        }

        public static void Run1()
        {
            int[] crabs = input.First().Split(',').Select(x => int.Parse(x)).OrderBy(x => x).ToArray();

            int maxElement = crabs.Max();            
            long minFuel = int.MaxValue;

            for (int i = 0; i <= maxElement; i++)
            {
                int fuel = 0;
                foreach (int pos in crabs)
                {
                    fuel += Math.Abs(pos - i);
                }
                if (fuel < minFuel)
                {
                    minFuel = fuel;
                }
            }

            Console.WriteLine($"Day 7 Run1 -> Result: {minFuel}");
        }

        public static void Run2()
        {
            int[] crabs = input.First().Split(',').Select(x => int.Parse(x)).OrderBy(x => x).ToArray();

            int maxElement = crabs.Max();
            long minFuel = int.MaxValue;

            for (int i = 0; i <= maxElement; i++)
            {
                int fuel = 0;
                foreach (int pos in crabs)
                {
                    int distance = Math.Abs(pos - i);
                    fuel += (distance + 1) * distance / 2; 
                }
                
                minFuel = Math.Min(minFuel, fuel);                
            }

            Console.WriteLine($"Day 7 Run2 -> Result: {minFuel}");
        }
    }
}
