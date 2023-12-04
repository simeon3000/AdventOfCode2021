namespace AdventOfCode2022;

public class Day09 : IDay
{
    private const string file = @"inputs\day09.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    private readonly HashSet<Point> visited = new() { new Point { X = 0, Y = 0 } };
    private Point head = new();
    private Point tail = new();
    string headPosition = "even";

    public long Run1()
    {
        foreach (string line in input)
        {
            Move1(line.Split());
        }

        return visited.Count;
    }

    private void Move1(string[] line)
    {
        string direction = line[0];
        int value = int.Parse(line[1]);
        switch (headPosition)
        {
            case "topLeft":
                switch (direction)
                {
                    case "U":
                        for (int i = 0; i < value; i++)
                        {
                            if (i == 0)
                            {
                                tail.X--;
                            }

                            tail.Y++;
                            visited.Add(tail);
                        }

                        head.Y += value;
                        break;
                    case "R":
                        for (int i = 0; i < value; i++)
                        {

                        }
                        break;
                    case "D":
                        break;
                    case "L":
                        break;
                    default:
                        break;
                }
                break;
            case "top":
                switch (direction)
                {
                    case "U":
                        for (int i = 0; i < value; i++)
                        {
                            tail.Y++;
                            visited.Add(tail);
                        }

                        head.Y += value;
                        break;
                    case "R":
                        break;
                    case "D":
                        break;
                    case "L":
                        break;
                    default:
                        break;
                }
                break;
            case "topRight":
                switch (direction)
                {
                    case "U":
                        for (int i = 0; i < value; i++)
                        {
                            if (i == 0)
                            {
                                tail.X++;
                            }

                            tail.Y++;
                            visited.Add(tail);
                        }

                        head.Y += value;
                        break;
                    case "R":
                        break;
                    case "D":
                        break;
                    case "L":
                        break;
                    default:
                        break;
                }
                break;
            case "left":
                switch (direction)
                {
                    case "U":
                        for (int i = 1; i < value; i++)
                        {
                            if (value == 1)
                            {
                                break;
                            }
                            if (i == 1)
                            {
                                tail.X--;
                            }

                            tail.Y++;
                            visited.Add(tail);
                        }

                        head.Y += value;
                        break;
                    case "R":
                        break;
                    case "D":
                        break;
                    case "L":
                        break;
                    default:
                        break;
                }
                break;
            case "even":
                switch (direction)
                {
                    case "U":
                        for (int i = 1; i < value; i++)
                        {                            
                            tail.Y++;
                            visited.Add(tail);
                        }

                        head.Y += value;
                        break;
                    case "R":
                        break;
                    case "D":
                        break;
                    case "L":
                        break;
                    default:
                        break;
                }
                break;
            case "right":
                switch (direction)
                {
                    case "U":
                        for (int i = 1; i < value; i++)
                        {
                            if (value == 1)
                            {
                                break;
                            }
                            if (i == 1)
                            {
                                tail.X++;
                            }

                            tail.Y++;
                            visited.Add(tail);
                        }

                        head.Y += value;
                        break;
                    case "R":
                        break;
                    case "D":
                        break;
                    case "L":
                        break;
                    default:
                        break;
                }
                break;
            case "downLeft":
                switch (direction)
                {
                    case "U":
                        break;
                    case "R":
                        break;
                    case "D":
                        break;
                    case "L":
                        break;
                    default:
                        break;
                }
                break;
            case "down":
                switch (direction)
                {
                    case "U":
                        break;
                    case "R":
                        break;
                    case "D":
                        break;
                    case "L":
                        break;
                    default:
                        break;
                }
                break;
            case "downRight":
                switch (direction)
                {
                    case "U":
                        break;
                    case "R":
                        break;
                    case "D":
                        break;
                    case "L":
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

        visited.Add(tail);
    }

    public long Run2()
    {
        return 1;
    }

}
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}
