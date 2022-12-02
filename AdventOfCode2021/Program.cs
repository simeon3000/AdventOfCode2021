using System;
using Shared;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {            
            IDay day = new Day13();

            Helper.PrintResult(day, "Run1", day.Run1());
            Helper.PrintResult(day, "Run2", day.Run2());

            Console.ReadKey();
        }
    }
}
