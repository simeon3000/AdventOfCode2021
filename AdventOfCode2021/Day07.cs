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

        public long Run1() => Calculate(Run1CalcLogic);                 
        public long Run2() => Calculate(Run2CalcLogic);

        private static int Run1CalcLogic(int x) => x;
        private static int Run2CalcLogic(int x) => (x + 1) * x / 2;

        private long Calculate(Func<int, int> calcLogic)
        {
            long minFuel = int.MaxValue;

            for (int i = 0; i <= maxElement; i++)
            {
                int fuel = 0;
                foreach (int pos in crabs)
                {
                    int distance = Math.Abs(pos - i);
                    fuel += calcLogic(distance);
                }

                minFuel = Math.Min(minFuel, fuel);
            }

            return minFuel;
        }
    }
}
