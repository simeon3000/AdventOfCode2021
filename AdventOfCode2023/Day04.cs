namespace AdventOfCode2023;

public class Day04 : IDay
{
    private const string file = @"inputs\day04.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);
    private static readonly string[] separator = [":", "|"];

    public long Run1()
    {
        int result = 0;
        foreach (string line in input)
        {
            string[] tokens = line.Split(separator, StringSplitOptions.None);
            int[] winners = tokens[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] myNumbers = tokens[2].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int cnt = 0;
            foreach (int current in myNumbers)
            {
                if (winners.Contains(current))
                {
                    cnt++;
                }
            }

            if (cnt > 0)
            {
                result += (int)Math.Pow(2, cnt - 1);
            }
        }

        return result;
    }

    public long Run2()
    {
        Dictionary<int, Card> cards = [];

        foreach (string line in input)
        {
            string[] tokens = line.Split(separator, StringSplitOptions.None);
            int cardNumber = int.Parse(tokens[0].Split().Last());
            int[] winners = tokens[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] myNumbers = tokens[2].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int cnt = 0;
            foreach (int current in myNumbers)
            {
                if (winners.Contains(current))
                {
                    cnt++;
                }
            }

            cards.Add(cardNumber, new Card(Wins: cnt));
        }

        foreach (var card in cards)
        {
            for (int i = 0; i < card.Value.Counts; i++)
            {
                for (int j = 1; j <= card.Value.Wins; j++)
                {
                    cards[card.Key + j].Counts++;
                }
            }
        }

        int result = cards.Values.Sum(x => x.Counts);
        return result;
    }
}

public record Card(int Wins)
{
    public int Counts { get; set; } = 1;
}
