using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day10 : IDay
    {
        private const string file = @"inputs\day10.txt";
        private static readonly List<string> input = Helper.GetInputLines(file);

        private static readonly char[] openingBrackets = new char[4] { '(', '[', '{', '<' };
        private static readonly char[] closingBrackets = new char[4] { ')', ']', '}', '>' };


        public long Run1()
        {
            Dictionary<char, int> bracketsValues = new()
                { [')'] = 3, [']'] = 57, ['}'] = 1197, ['>'] = 25137 };

            int result = 0;
            foreach (string line in input)
            {
                Stack<char> stack = new();
                foreach (char c in line)
                {
                    if (openingBrackets.Contains(c))
                    {
                        stack.Push(c);
                    }
                    else if (closingBrackets.Contains(c))
                    {
                        if (!stack.TryPeek(out char stackChar))
                        {
                            result += bracketsValues[c];
                            break;
                        }

                        bool isCorrect = false;
                        for (int i = 0; i < closingBrackets.Length; i++)
                        {

                            if (c == closingBrackets[i] && stackChar == openingBrackets[i])
                            {
                                isCorrect = true;
                            }
                        }

                        if (isCorrect)
                        {
                            _ = stack.Pop();
                        }
                        else
                        {
                            result += bracketsValues[c];
                            break;
                        }

                    }
                }
            }

            return result;
        }

        public long Run2()
        {
            throw new NotImplementedException();
        }
    }
}
