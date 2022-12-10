namespace AdventOfCode2022;

public class Day07 : IDay
{
    private const string file = @"inputs\day07.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    private readonly Dir root = new();
    private int minSpace;

    public long Run1()
    {
        FillDirs();
        return Calc1(root, 0);
    }

    private int Calc1(Dir dir, int sum)
    {
        if (dir.Size <= 100000)
        { 
            sum += dir.Size; 
        }

        foreach (Dir child in dir.Dirs.Values)
        {
          sum = Calc1(child, sum);
        }

        return sum;
    }

    public long Run2() => Calc2();

    private int Calc2()
    {
        minSpace = root.Size - 40000000;

        List<int> dirs = AddBigDirs(root, new List<int>());
        dirs.Sort();

        return dirs.First();
    }

    private List<int> AddBigDirs(Dir dir, List<int> bigDirs)
    {
        if (dir.Size >= minSpace)
        {
            bigDirs.Add(dir.Size);
        }

        foreach (Dir child in dir.Dirs.Values)
        {
            bigDirs = AddBigDirs(child, bigDirs);
        }

        return bigDirs;
    }

    private void FillDirs()
    {
        Dir currentDir = root;
        foreach (string line in input.Skip(1))
        {
            string[] l = line.Split();
            if (l[0] == "$")
            {
                string command = l[1];
                if (command == "cd")
                {
                    string dirName = l[2];
                    if (dirName == "..")
                    {
                        currentDir = currentDir.PreviousDir;

                    }
                    else
                    {
                        currentDir = currentDir.Dirs[dirName];
                    }
                }
            }
            else if (l[0] == "dir")
            {
                currentDir.Dirs.Add(l[1], new Dir { PreviousDir = currentDir });
            }
            else
            {
                currentDir.FilesSize += int.Parse(l[0]);
            }
        }
    }
}

public record Dir
{    
    public Dir PreviousDir { get; init; }
    public int FilesSize { get; set; }
    public Dictionary<string, Dir> Dirs { get; } = new();
    public int Size => FilesSize + Dirs.Values.Sum(x => x.Size);
}
