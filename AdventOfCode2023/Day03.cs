namespace AdventOfCode2023;

public class Day03 : IDay
{
    private const string file = @"inputs\day03.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    private static readonly int size = input.First().Length;
    private readonly char[,] matrix = new char[size, size];

    public long Run1()
    {
        FillMatrix();

        int result = 0;
        string number = "";
        (int, int) endIndex = (0, 0);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                char c = matrix[i, j];
                if (char.IsDigit(c))
                {
                    number += c;
                    endIndex = (i, j);
                    continue;
                }

                if (!string.IsNullOrEmpty(number))
                {
                    if (IsPartNumber(endIndex, number.Length))
                    {
                        result += int.Parse(number);
                    }

                    number = "";
                }
            }
        }

        return result;
    }

    public long Run2()
    {

        return 2;
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

    private bool IsPartNumber((int Row, int Col) endIndex, int numberLength)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j <= numberLength + 1; j++)
            {
                try
                {
                    int charRow = endIndex.Row - 1 + i;
                    int charCol = endIndex.Col - numberLength + j;

                    char c = matrix[charRow, charCol];
                    if (CharIsSymbol(c))
                    {
                        return true;
                    }
                }
                catch (IndexOutOfRangeException)
                { }
            }
        }

        return false;
    }

    private static bool CharIsSymbol(char c) => !char.IsDigit(c) && c != '.';
}
