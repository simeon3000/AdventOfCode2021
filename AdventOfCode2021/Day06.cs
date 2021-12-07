using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day06 : IDay
    {
        private const string file = @"inputs\day06.txt";
        private const int run1Days = 80;
        private const int run2Days = 256;

        private static readonly List<string> input = Helper.GetInputLines(file);

        public long Run1()
        {
            List<int> fishes = GetFishes();

            for (int i = 1; i <= run1Days; i++)
            {
                List<int> newFishes = new();

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

            return fishes.Count();
        }

        public long Run2()
        {
            List<int> fishes = GetFishes();
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

            for (var i = 0; i < run2Days; i++)
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
            return result;
        }

        private List<int> GetFishes() => input.First().Split(',').Select(x => int.Parse(x)).ToList();
    }
}
