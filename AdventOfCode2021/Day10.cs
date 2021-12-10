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
                                break;
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
            Dictionary<char, int> bracketsValues = new()
                { [')'] = 1, [']'] = 2, ['}'] = 3, ['>'] = 4 };

            List<long> scores = new();

            foreach (string line in input)
            {
                Stack<char> stack = new();
                bool isBroken = false;                

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
                            isBroken = true;
                            break;
                        }

                        bool isCorrect = false;
                        for (int i = 0; i < closingBrackets.Length; i++)
                        {

                            if (c == closingBrackets[i] && stackChar == openingBrackets[i])
                            {
                                isCorrect = true;
                                break;
                            }
                        }

                        if (isCorrect)
                        {
                            _ = stack.Pop();
                        }
                        else
                        {                            
                            isBroken = true;
                            break;
                        }
                    }
                }

                if (stack.Count > 0 && !isBroken)
                {
                    long currentScore = 0;
                    while (stack.Count > 0)
                    {
                        char current = stack.Pop();                        
                        for (int i = 0; i < openingBrackets.Length; i++)
                        {
                            if (current == openingBrackets[i])
                            {
                                currentScore = currentScore * 5 + bracketsValues[closingBrackets[i]];
                                break;
                            }
                        }                        
                    }

                    scores.Add(currentScore);
                }
            }

            int resultIndex = scores.Count / 2;
            List<long> ordered = scores.OrderBy(x => x).ToList();
            long result = ordered[resultIndex];

            return result;
        }
    }
}
