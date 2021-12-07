using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            IDay day = new Day01();

            Helper.PrintResult(day, "Run1", day.Run1());
            Helper.PrintResult(day, "Run2", day.Run2());

            Console.ReadKey();
        }
    }
}
