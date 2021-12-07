using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day03 : IDay
    {
        private const string file = @"inputs\day03.txt";
        private readonly List<string> input = Helper.GetInputLines(file);

        public long Run1()
        {
            int[] counters = new int[input[0].Length];

            foreach (string line in input)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    int number = int.Parse(line[i].ToString());
                    counters[i] += number;
                }
            }

            string gammaRate = "";
            string epsilonRate = "";

            foreach (int number in counters)
            {
                if (number > input.Count / 2)
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
                else
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }
            }

            int gamma = Convert.ToInt32(gammaRate, 2);
            int epsilon = Convert.ToInt32(epsilonRate, 2);

            long result = gamma * epsilon;
            return result;
        }

        public long Run2()
        {
            int oxigen = Convert.ToInt32(GetValueByLeadingChar('1'), 2);
            int co2 = Convert.ToInt32(GetValueByLeadingChar('0'), 2);

            long result = oxigen * co2;
            return result;
        }

        private string GetValueByLeadingChar(char leadingChar)
        {
            char lead = leadingChar == '1' ? '1' : '0';
            char second = leadingChar == '1' ? '0' : '1';

            int cnt = 0;
            int cntValue = 0;

            List<string> workList = input;
            while (workList.Count > 1)
            {
                foreach (string line in workList)
                {
                    int number = int.Parse(line[cnt].ToString());
                    cntValue += number;
                }

                char c = cntValue >= workList.Count / 2.0 ? lead : second;

                workList = workList.Where(x => x[cnt] == c).ToList();

                cnt++;
                cntValue = 0;
            }

            return workList.First();
        }
    }
}
