using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day6
    {
        private const string file = @"c:\temp\day6.txt";
        private const int days1 = 80;
        private const int days2 = 256;

        private static readonly List<string> input;

        static Day6()
        {
            input = Helper.GetInputLines(file);            
        }

        public static void Run1()
        {
            List<int> fishes = input.First().Split(',').Select(x => int.Parse(x)).ToList();

            for (int i = 1; i <= days1; i++)
            {
                var newFishes = new List<int>();
                
                for (int j = 0; j < fishes.Count; j++)
                {
                    if (fishes[j] == 0)
                    {
                        fishes[j] = 6;
                        newFishes.Add(8);
                    }
                    else
                    {
                        fishes[j]--;
                    }
                }

                fishes.AddRange(newFishes);
            }

            Console.WriteLine($"Day 6 Run1 -> Result: {fishes.Count}");
        }

        public static void Run2()
        {
            List<int> fishes = input.First().Split(',').Select(x => int.Parse(x)).ToList();
            var fishCount = new Dictionary<int, long>
                {
                    {0, 0},
                    {1, 0},
                    {2, 0},
                    {3, 0},
                    {4, 0},
                    {5, 0},
                    {6, 0},
                    {7, 0},
                    {8, 0}
                };

            fishes.GroupBy(x => x).ToList().ForEach(x => fishCount[x.Key] = x.Count());

            for (var i = 0; i < days2; i++)
            {
                long? tempVal = null;
                foreach (var key in fishCount.Keys.OrderByDescending(x => x))
                {
                    var count = tempVal ?? fishCount[key];
                    var newKey = key == 0 ? 6 : key - 1;

                    if (key == 0)
                    {
                        fishCount[8] = count;
                        fishCount[6] += count;
                    }
                    else
                    {
                        tempVal = fishCount[newKey];
                        fishCount[newKey] = count;
                    }
                }
            }

            long result = fishCount.Values.Sum();

            Console.WriteLine($"Day 6 Run2 -> Result: {result}");
        }
    }
}
