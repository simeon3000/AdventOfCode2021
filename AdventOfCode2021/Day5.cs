using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    public class Day5
    {
        private const string file = @"c:\temp\day5.txt";
        private const int size = 1000;

        private static readonly List<string> input;
        private const string pattern = @"(\d+),(\d+) -> (\d+),(\d+)";
        private static readonly List<LineCoordinates> coordinates;

        static Day5()
        {
            input = Helper.GetInput(file);
            coordinates = GetCoordinates();
        }

        public static void Run1()
        {           
            int[,] board = new int[size, size];
            foreach (LineCoordinates c in coordinates)
            {
                
                if (c.IsHorizontalLine)
                {
                    FillHorizontal(board, c);
                }
                else if (c.IsVerticalLine)
                {
                    FillVertical(board, c);
                }
            }

            Console.WriteLine($"Day 5 Run1 -> Result: {CalcResult(board)}");
        }

        public static void Run2()
        {            
            int[,] board = new int[size, size];
            foreach (LineCoordinates c in coordinates)
            {

                if (c.IsHorizontalLine)
                {
                    FillHorizontal(board, c);
                }
                else if (c.IsVerticalLine)
                {
                    FillVertical(board, c);
                }
                else
                {
                    FillDiagonal(board, c);
                }
            }

            Console.WriteLine($"Day 5 Run2 -> Result: {CalcResult(board)}");            
        }

        private static void FillDiagonal(int[,] board, LineCoordinates c)
        {
            int distance = Math.Abs(c.X1 - c.X2);
            int horizontalSign = c.X1 < c.X2 ? 1 : -1;
            int verticalSignSign = c.Y1 < c.Y2 ? 1 : -1;
            
            for (int i = 0; i <= distance; i++)
            {
                board[c.X1 + i * horizontalSign, c.Y1 + i * verticalSignSign]++;
            }            
        }

        private static void FillVertical(int[,] board, LineCoordinates c)
        {
            int startPointY = Math.Min(c.Y1, c.Y2);
            int distance = Math.Abs(c.Y1 - c.Y2);

            for (int i = startPointY; i <= startPointY + distance; i++)
            {
                board[c.X1, i]++;
            }
        }

        private static void FillHorizontal(int[,] board, LineCoordinates c)
        {
            int startPointX = Math.Min(c.X1, c.X2);
            int distance = Math.Abs(c.X1 - c.X2);

            for (int i = startPointX; i <= startPointX + distance; i++)
            {
                board[i, c.Y1]++;
            }
        }

        private static List<LineCoordinates> GetCoordinates()
        {
            var coordinates = new List<LineCoordinates>();
            foreach (string line in input)
            {
                Match match = Regex.Matches(line, pattern).First();
                int x1 = int.Parse(match.Groups[1].ToString());
                int y1 = int.Parse(match.Groups[2].ToString());
                int x2 = int.Parse(match.Groups[3].ToString());
                int y2 = int.Parse(match.Groups[4].ToString());
                
                LineCoordinates currentLine = new LineCoordinates(x1, y1, x2, y2);
                coordinates.Add(currentLine);
            }

            return coordinates;
        }

        private static int CalcResult(int[,] board)
        {
            int result = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] > 1)
                    {
                        result++;
                    }
                }
            }

            return result;            
        }

        private class LineCoordinates
        {
            public LineCoordinates(int x1, int y1, int x2, int y2)
            {
                X1 = x1;
                Y1 = y1;
                X2 = x2;
                Y2 = y2;
            }

            public int X1 { get; }
            public int Y1 { get; }
            public int X2 { get; }
            public int Y2 { get; }

            public bool IsHorizontalLine => Y1 == Y2;
            public bool IsVerticalLine => X1 == X2;
        }
    }
}
