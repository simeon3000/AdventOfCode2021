using System.Text;

namespace AdventOfCode2022;

public class Day05 : IDay
{
    private const string file = @"inputs\day05.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    //List<List<string>> inputList = new()
    //{
    //    new List<string>{ "Z", "N" },
    //    new List<string>{ "M", "C", "D" },
    //    new List<string>{ "P" }
    //};
    List<List<string>> inputList = new()
    {
        new List<string>( new string[] { "Q", "S", "W", "C", "Z", "V", "F", "T" } ),
        new List<string>( new string[] { "Q", "R", "B" } ),
        new List<string>( new string[] { "B", "Z", "T", "Q", "P", "M", "S" } ),
        new List<string>( new string[] { "D", "V", "F", "R", "Q", "H" } ),
        new List<string>( new string[] { "J", "G", "L", "D", "B", "S", "T", "P" } ),
        new List<string>( new string[] { "W", "R", "T", "Z" } ),
        new List<string>( new string[] { "H", "Q", "M", "N", "S", "F", "R", "J" } ),
        new List<string>( new string[] { "R", "N", "F", "H", "W" } ),
        new List<string>( new string[] { "J", "Z", "T", "Q", "P", "R", "B" } )
    };

    private int cnt, from, to;
    public long Run1()
    {
        List<Stack<string>> stacks = GetStacks();
        foreach (string line in input.Where(x => x.Contains("move")))
        {
            GetValues(line);
            for (int i = 0; i < cnt; i++)
            {
                stacks[to - 1].Push(stacks[from - 1].Pop());
            }
        }

        PrintResult(stacks);
        return 1;
    }

    public long Run2()
    {
        List<Stack<string>> stacks = GetStacks();
        foreach (string line in input.Where(x => x.Contains("move")))
        {
            GetValues(line);
            Stack<string> temp = new();
            for (int i = 0; i < cnt; i++)
            {
                temp.Push(stacks[from - 1].Pop());
            }

            foreach (string item in temp)
            {
                stacks[to - 1].Push(item);
            }
        }

        PrintResult(stacks);
        return 1;
    }

    private List<Stack<string>> GetStacks()
    {
        List<Stack<string>> stacks = new();
        foreach (List<string> list in inputList)
        {
            string[] tempArray = new string[list.Count];
            list.CopyTo(tempArray);
            stacks.Add(new Stack<string>(tempArray));
        }

        return stacks;
    }

    private void GetValues(string line)
    {
        string[] val = line.Split(' ');
        cnt = int.Parse(val[1]);
        from = int.Parse(val[3]);
        to = int.Parse(val[5]);
    }

    private void PrintResult(List<Stack<string>> stacks)
    {
        StringBuilder result = new();
        foreach (Stack<string> stack in stacks)
        {
            result.Append(stack.Pop());
        }

        Console.WriteLine(result);
    }
}
