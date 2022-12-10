namespace AdventOfCode2022;

public class Day08 : IDay
{
    private const string file = @"inputs\day08.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    private static readonly int size = input.First().Length;
    private readonly char[,] matrix = new char[size, size]; 

    public long Run1()
    {        
        FillMatrix();

        int sum = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i == 0 || i == size - 1 || j == 0 || j == size - 1)
                {
                    sum++;
                }
                else if (Left(i, j) || Right(i, j) || Up(i, j) || Down(i, j))
                {
                    sum++;
                }
            }
        }

        return sum;
    }

    private bool Left(int i, int j)
    {
        for (int k = 0; k < j; k++)
        {
            if (matrix[i, k] >= matrix[i, j])
            {
                return false;
            }
        }

        return true;
    }
    private bool Right(int i, int j)
    {
        for (int k = 0; k < size - j - 1; k++)
        {
            if (matrix[i, j + k + 1] >= matrix[i, j])
            {
                return false;
            }
        }

        return true;
    }
    private bool Up(int i, int j)
    {
        for (int k = 0; k < i; k++)
        {
            if (matrix[k, j] >= matrix[i, j])
            {
                return false;
            }
        }

        return true;
    }
    private bool Down(int i, int j)
    {
        for (int k = 0; k < size - i - 1; k++)
        {
            if (matrix[i + k + 1, j] >= matrix[i, j])
            {
                return false;
            }
        }

        return true;
    }

    public long Run2()
    {
        int maxSum = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i != 0 && i != size - 1 && j != 0 && j != size - 1)
                {
                    int left = SumLeft(i, j);
                    int right = SumRight(i, j);
                    int up = SumUp(i, j);
                    int down = SumDown(i, j);
                    int current = left * right * up * down;

                    if (current > maxSum)
                    {
                        maxSum = current;
                    }
                }
            }
        }

        return maxSum;
    }
    private int SumLeft(int i, int j)
    {
        int sum = 0;
        for (int k = j - 1; k >= 0; k--)
        {
            sum++;
            if (matrix[i, k] >= matrix[i, j])
            {
                break;
            }
        }

        return sum;
    }
    private int SumRight(int i, int j)
    {
        int sum = 0;
        for (int k = 0; k < size - j - 1; k++)
        {
            sum++;
            if (matrix[i, j + k + 1] >= matrix[i, j])
            {
                break;
            }
        }

        return sum;
    }
    private int SumUp(int i, int j)
    {
        int sum = 0;
        for (int k = i - 1; k >= 0; k--)
        {
            sum++;
            if (matrix[k, j] >= matrix[i, j])
            {
                break;
            }
        }

        return sum;
    }
    private int SumDown(int i, int j)
    {
        int sum = 0;
        for (int k = 0; k < size - i - 1; k++)
        {
            sum++;
            if (matrix[i + k + 1, j] >= matrix[i, j])
            {
                break;
            }
        }

        return sum;
    }

    private void FillMatrix()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = input[i][j];
            }
        }
    }
}
