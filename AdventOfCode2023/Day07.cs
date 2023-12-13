namespace AdventOfCode2023;

public class Day07 : IDay
{
    private const string file = @"inputs\day07.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    private static readonly List<char> cardPowers1 = ['2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'];
    private static readonly List<char> cardPowers2 = ['J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A'];
    private readonly List<Hand> hands = [];

    public long Run1()
    {
        foreach (string line in input)
        {
            string[] tokens = line.Split();
            string handString = tokens[0];
            int bid = int.Parse(tokens[1]);

            HandType type = GetHandType1(handString);
            Hand hand = new(handString, bid, type);
            hands.Add(hand);
        }

        List<Hand> orderedHands = [.. hands.OrderBy(x => (int)x.Type).ThenBy(x => x, new CardComparer(cardPowers1))];

        long result = 0;
        for (int i = 0; i < orderedHands.Count; i++)
        {
            result += orderedHands[i].Bid * (i + 1);
        }

        return result;
    }

    private HandType GetHandType1(string handString)
    {
        Dictionary<char, int> dict = [];
        foreach (char c in handString)
        {
            if (!dict.TryGetValue(c, out _))
            {
                dict.Add(c, 0);
            }

            dict[c]++;
        }

        if (dict.Count == 5)
        {
            return HandType.HighCard;
        }
        else if (dict.Count == 4)
        {
            return HandType.OnePair;
        }
        else if (dict.Count == 3)
        {
            if (dict.Any(x => x.Value == 2))
            {
                return HandType.TwoPair;
            }
            return HandType.ThreeOfAKind;
        }
        else if (dict.Count == 2)
        {
            if (dict.Any(x => x.Value == 3))
            {
                return HandType.FullHouse;
            }

            return HandType.FourOfAKind;
        }
        else
        {
            return HandType.FiveOfAKind;
        }
    }

    public long Run2()
    {

        return 2;
    }
}

public record Hand(string Cards, int Bid, HandType Type);

public enum HandType
{
    HighCard = 1,
    OnePair = 2,
    TwoPair = 3,
    ThreeOfAKind = 4,
    FullHouse = 5,
    FourOfAKind = 6,
    FiveOfAKind = 7
}

public class CardComparer(List<char> cardPowers) : IComparer<Hand>
{
    public int Compare(Hand? x, Hand? y)
    {
        if (x is null) return -1;
        if (y is null) return 1;

        for (int i = 0; i < x.Cards.Length; i++)
        {
            if (x.Cards[i].Equals(y.Cards[i]))
            {
                continue;
            }

            int xPower = cardPowers.IndexOf(x.Cards[i]);
            int yPower = cardPowers.IndexOf(y.Cards[i]);

            return xPower.CompareTo(yPower);
        }

        return 0;
    }
}