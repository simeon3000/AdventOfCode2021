using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day07 : IDay
    {
        private const string file = @"inputs\day07.txt";        
        private static readonly List<string> input = Helper.GetInputLines(file);
        private static readonly int[] crabs = input.First().Split(',').Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
        private readonly int maxElement = crabs.Max();

        public long Run1()
        {                        
            long minFuel = int.MaxValue;

            for (int i = 0; i <= maxElement; i++)
            {
                int fuel = 0;
                foreach (int pos in crabs)
                {
                    fuel += Math.Abs(pos - i);
                }

                minFuel = Math.Min(minFuel, fuel);
            }

            return minFuel;
        }

        public long Run2()
        {            
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

            return minFuel;
        }        
    }
}
