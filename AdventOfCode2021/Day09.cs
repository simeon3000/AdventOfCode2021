using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day09 : IDay
    {
        private const string file = @"inputs\day09.txt";
        private static readonly List<string> input = Helper.GetInputLines(file);
        private static readonly int rows = input.Count + 2;
        private static readonly int cols = input[0].Length + 2;

        private readonly Element[,] matrix = GetMatrix(input);        

        public long Run1()
        {
            int result = 0;
            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < cols - 1; j++)
                {                    
                    GetNeighbors(i, j, out Element m, out Element mUp, out Element mLeft, out Element mRight, out Element mDown);

                    if (m.Value < mUp.Value && m.Value < mLeft.Value && m.Value < mRight.Value && m.Value < mDown.Value)
                    {
                        result += m.Value + 1;
                    }
                }
            }

            return result;
        }

        public long Run2()
        {
            List<int> basins = new();

            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < cols - 1; j++)
                {
                    GetNeighbors(i, j, out Element m, out Element mUp, out Element mLeft, out Element mRight, out Element mDown);

                    if (m.Value < mUp.Value && m.Value < mLeft.Value && m.Value < mRight.Value && m.Value < mDown.Value)
                    {
                        int res = 0;
                        CalcBasin(i, j, ref res);
                        basins.Add(res);
                    }
                }
            }

            int result = 1;
            basins.OrderByDescending(x => x).Take(3).ToList().ForEach(x => result *= x);

            return result;
        }

        private void CalcBasin(int i, int j, ref int res)
        {
            res++;
            matrix[i, j].IsMarked = true;

            GetNeighbors(i, j, out Element m, out Element mUp, out Element mLeft, out Element mRight, out Element mDown);

            if (IsBasinElement(mUp))
            {
                CalcBasin(i - 1, j, ref res);
            }
            if (IsBasinElement(mLeft))
            {
                CalcBasin(i, j - 1, ref res);
            }
            if (IsBasinElement(mRight))
            {
                CalcBasin(i, j + 1, ref res);
            }
            if (IsBasinElement(mDown))
            {
                CalcBasin(i + 1, j, ref res);
            }            
        }

        private static bool IsBasinElement(Element m)
        {
            return m.Value != 9 && m.Value != 10 && !m.IsMarked;
        }

        private static Element[,] GetMatrix(List<string> input)
        {
            Element[,] matr = new Element[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 || i == rows - 1 || j == 0 || j == cols - 1)
                    {
                        matr[i, j] = new Element { Value = 10 };
                    }
                    else
                    {
                        matr[i, j] = new Element { Value = int.Parse(input[i - 1][j - 1].ToString()) };
                    }
                }
            }

            return matr;
        }

        private void GetNeighbors(int i, int j, out Element m, out Element mUp, out Element mLeft, out Element mRight, out Element mDown)
        {
            m = matrix[i, j];
            mUp = matrix[i - 1, j];
            mLeft = matrix[i, j - 1];
            mRight = matrix[i, j + 1];
            mDown = matrix[i + 1, j];
        }        

        private class Element
        {
            public int Value { get; set; }
            public bool IsMarked { get; set; }            
        }
    }
}
