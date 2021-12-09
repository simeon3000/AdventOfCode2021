using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public class Day08 : IDay
    {
        private const string file = @"inputs\day08.txt";
        private static readonly List<string> input = Helper.GetInputLines(file);
        private readonly List<List<string>> patterns = new();
        private readonly List<List<string>> values = new();

        private readonly Dictionary<string, List<int>> numbersPositions = new()
        {
            ["1"] = new List<int> { 3, 6 },
            ["2"] = new List<int> { 1, 3, 4, 5, 7 },
            ["3"] = new List<int> { 1, 3, 4, 6, 7 },
            ["4"] = new List<int> { 2, 3, 4, 6 },
            ["5"] = new List<int> { 1, 2, 4, 6, 7 },
            ["6"] = new List<int> { 1, 2, 4, 5, 6, 7 },
            ["7"] = new List<int> { 1, 3, 6 },
            ["8"] = new List<int> { 1, 2, 3, 4, 5, 6, 7 },
            ["9"] = new List<int> { 1, 2, 3, 4, 6, 7 },
            ["0"] = new List<int> { 1, 2, 3, 5, 6, 7 }
        };

        public Day08()
        {
            GetInputLists();
        }

        public long Run1()
        {
            int[] knownNumbers = new int[4] { 2, 3, 4, 7 };

            int result = 0;
            foreach (List<string> line in values)
            {
                result += line.Where(x => knownNumbers.Contains(x.Length)).Count();
            }

            return result;
        }

        public long Run2()
        {
            int result = 0;
            for (int i = 0; i < patterns.Count; i++)
            {
                List<string> currentPatterns = patterns[i];
                string one = currentPatterns.Where(x => x.Length == 2).First();
                string seven = currentPatterns.Where(x => x.Length == 3).First();
                string four = currentPatterns.Where(x => x.Length == 4).First();
                List<string> twoThreeFive = currentPatterns.Where(x => x.Length == 5).ToList();
                List<string> sixNineZero = currentPatterns.Where(x => x.Length == 6).ToList();

                char temp_pos_3 = one[0];
                char temp_pos_6 = one[1];
                char pos_1 = seven.Except(one).First();

                char[] oneSeven = new char[3] { pos_1, temp_pos_3, temp_pos_6 };
                char temp_pos_2 = four.Except(oneSeven).First();
                char temp_pos_4 = four.Except(oneSeven).Last();

                int countTempPos2char = 0;
                foreach (string s in twoThreeFive)
                {
                    if (s.Contains(temp_pos_2))
                    {
                        countTempPos2char++;
                    }
                }
                char pos_4 = countTempPos2char == 3 ? temp_pos_2 : temp_pos_4;
                char pos_2 = countTempPos2char == 3 ? temp_pos_4 : temp_pos_2;

                List<string> sixNine = sixNineZero.Where(x => x.Contains(pos_4)).ToList();
                string zero = sixNineZero.Except(sixNine).First();
                char[] oneTwoThreeFourSix = new char[5] { pos_1, pos_2, temp_pos_3, pos_4, temp_pos_6 };

                char temp_pos_5 = zero.Except(oneTwoThreeFourSix).First();
                char temp_pos_7 = zero.Except(oneTwoThreeFourSix).Last();

                int countTempPos7 = 0;
                foreach (string s in sixNine)
                {
                    if (s.Contains(temp_pos_7))
                    {
                        countTempPos7++;
                    }
                }
                char pos_7 = countTempPos7 == 2 ? temp_pos_7 : temp_pos_5;
                char pos_5 = countTempPos7 == 2 ? temp_pos_5 : temp_pos_7;

                bool areCorrectTemp_3_And_6 = false;
                foreach (string s in sixNine)
                {
                    if (s.Contains(pos_1) && s.Contains(pos_2) && s.Contains(pos_4) &&
                        s.Contains(pos_5) && s.Contains(temp_pos_6) && s.Contains(pos_7) && !s.Contains(temp_pos_3))
                    {
                        areCorrectTemp_3_And_6 = true;
                    }
                }
                char pos_3 = areCorrectTemp_3_And_6 ? temp_pos_3 : temp_pos_6;
                char pos_6 = areCorrectTemp_3_And_6 ? temp_pos_6 : temp_pos_3;

                Dictionary<char, int> lettersPositions = new()
                {
                    [pos_1] = 1,
                    [pos_2] = 2,
                    [pos_3] = 3,
                    [pos_4] = 4,
                    [pos_5] = 5,
                    [pos_6] = 6,
                    [pos_7] = 7
                };

                StringBuilder numberString = new();
                foreach (string digitString in values[i])
                {
                    string d = CalculateDigit(digitString, lettersPositions);
                    numberString.Append(d);
                }

                result += int.Parse(numberString.ToString());
            }

            return result;
        }

        private string CalculateDigit(string digitString, Dictionary<char, int> lettersPositions)
        {
            List<int> digitPositions = new();
            foreach (char c in digitString)
            {
                digitPositions.Add(lettersPositions[c]);
            }

            foreach (KeyValuePair<string, List<int>> number in numbersPositions)
            {
                if (Enumerable.SequenceEqual(digitPositions.OrderBy(x => x), number.Value))
                {
                    return number.Key;
                }
            }

            return null;
        }

        private void GetInputLists()
        {
            foreach (string line in input)
            {
                List<string> tokens = line.Split(new[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                patterns.Add(tokens.Take(10).ToList());
                values.Add(tokens.Skip(10).ToList());
            }
        }
    }
}
/*
 0:      1:      2:      3:      4:
 aaaa    ....    aaaa    aaaa    ....
b    c  .    c  .    c  .    c  b    c
b    c  .    c  .    c  .    c  b    c
 ....    ....    dddd    dddd    dddd
e    f  .    f  e    .  .    f  .    f
e    f  .    f  e    .  .    f  .    f
 gggg    ....    gggg    gggg    ....

  5:      6:      7:      8:      9:
 aaaa    aaaa    aaaa    aaaa    aaaa
b    .  b    .  .    c  b    c  b    c
b    .  b    .  .    c  b    c  b    c
 dddd    dddd    ....    dddd    dddd
.    f  e    f  .    f  e    f  .    f
.    f  e    f  .    f  e    f  .    f
 gggg    gggg    ....    gggg    gggg
 
   
    Positions as numbers:   
           ..1.. 
         2.     .3
          .     .
           ..4.. 
         5.     .6
          .     .
           ..7.. 
 
 */
