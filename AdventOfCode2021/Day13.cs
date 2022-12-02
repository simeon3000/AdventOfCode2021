using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    public class Day13 : IDay
    {
        private const string file = @"inputs\day13test.txt";
        private static readonly List<string> input = Helper.GetInputLines(file);

        private readonly int startRows;
        private readonly int startCols;
        private readonly int[,] startMatrix;

        private readonly List<Tuple<string, int>> folds;

        public Day13()
        {
            GetInputs(out startMatrix, out startRows, out startCols, out folds);
        }

        public long Run1()
        {
            int cnt = 0,
                rows = 0,
                cols = 0;
            int[,] matrix = startMatrix;
            int[,] newMatrix = null;
            foreach (Tuple<string, int> line in folds)
            {
                cnt = 0;
                string foldDirection = line.Item1;
                int foldNumber = line.Item2;

                switch (foldDirection)
                {
                    case "x":
                        rows = matrix.GetLength(0);
                        cols = matrix.GetLength(1) - foldNumber - 1;
                        newMatrix = new int[rows, cols];
                        cnt = StartVerticalFold(matrix, newMatrix, rows, cols, foldNumber);
                        break;
                    case "y":
                        rows = matrix.GetLength(0) - foldNumber - 1;
                        cols = matrix.GetLength(1);
                        newMatrix = new int[rows, cols];
                        cnt = StartHorizontalFold(matrix, newMatrix, rows, cols, foldNumber);
                        break;
                }
                //PrintMatrix(newMatrix, rows, cols);
                matrix = newMatrix;
            }
            
            return cnt;
        }

        private int StartVerticalFold(int[,] matrix, int[,] newMatrix, int rows, int cols, int foldNumber)
        {
            int cnt = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    //newMatrix[i, j] = matrix[i, j] == 1 || matrix[i, matrix.GetLength(1) - j - 1] == 1 ? 1 : 0;
                    newMatrix[i, j] += matrix[i, matrix.GetLength(1) - j - 1];
                    if (newMatrix[i, j] > 0)
                    {
                        cnt++;
                    }
                }
            }

            return cnt;
        }

        private int StartHorizontalFold(int[,] matrix, int [,] newMatrix, int rows, int cols, int foldNumber)
        {
            int cnt = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    //newMatrix[i, j] = matrix[i, j] == 1 || matrix[matrix.GetLength(0) - i - 1, j] == 1 ? 1 : 0;
                    newMatrix[i, j] += matrix[matrix.GetLength(0) - i - 1, j];
                    if (newMatrix[i, j] > 0)
                    {
                        cnt++;
                    }
                }
            }

            return cnt;
        }

        public long Run2()
        {
            throw new NotImplementedException();
        }

        private void PrintMatrix(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private void GetInputs(out int[,] startMatrix, out int startRows, out int startCols, out List<Tuple<string, int>> folds)
        {
            int idx = input.IndexOf("");
            List<string> matrixInput = input.Take(idx).ToList();

            List<int> xCoords = new();
            List<int> yCoords = new();
            foreach (string item in matrixInput)
            {
                var tokens = item.Split(',');
                xCoords.Add(int.Parse(tokens[0]));
                yCoords.Add(int.Parse(tokens[1]));
            }

            startRows = yCoords.Max() + 1;
            startCols = xCoords.Max() + 1;
            startMatrix = new int[startRows, startCols];

            for (int i = 0; i < xCoords.Count; i++)
            {
                startMatrix[yCoords[i], xCoords[i]] = 1;
            }

            List<string> foldsInput = input.Skip(idx + 1).ToList();
            string pattern = @"fold along ([x-y])=(\d+)";
            folds = new List<Tuple<string, int>>();
            foreach (string line in foldsInput)
            {
                Match match = Regex.Matches(line, pattern).First();
                folds.Add(new Tuple<string, int>(match.Groups[1].ToString(), int.Parse(match.Groups[2].ToString())));
            }
        }
    }
}
