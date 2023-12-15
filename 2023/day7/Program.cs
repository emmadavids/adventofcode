using System.Linq;

public class Program
{
    public static List<List<string>> ParseInput(List<string> lines)
    {
        List<List<string>> allGames = new List<List<string>>();
        foreach (string line in lines)
        {
            List<string> round = line.Split(" ").ToList();
            allGames.Add(round);
        }
        return allGames;
    }

    private static int SortByType(List<string> hand)
    {
        var handChars = hand[0].ToCharArray();
        var jokers = handChars.Where(c=> c == 'J').Count();
        var orderedHand = hand[0].ToCharArray()
                            .Where(c => c != 'J') 
                            .GroupBy(c => c)
                            .OrderByDescending(c => c.Count());

        if (jokers == 5)
        {
            return 1;
        }

        switch(orderedHand)
        {
            case var g when g.First().Count() + jokers == 5:
                return 1;
            case var g when g.ElementAt(0).Count() + jokers == 4:
                return 2;
            case var g when g.ElementAt(0).Count() + jokers == 3 &&
                orderedHand.ElementAt(1).Count() == 2:
                return 3;
            case var g when g.ElementAt(0).Count() + jokers == 3:
                return 4;
            case var g when g.ElementAt(0).Count() + jokers == 2 &&
                g.ElementAt(1).Count() == 2:
                return 5;
            case var g when g.ElementAt(0).Count() + jokers == 2:
                return 6;
            // case var g when g.ElementAt(0).Count() + jokers == 1:
            //     return 7;
            default:
                return 8;
        }
    }

static void Main()
    {
        Dictionary<char, int> cardValues = new Dictionary<char, int>
        {
            {'A', 14},
            {'K', 13},
            {'Q', 12},
            {'J', 1},
            {'T', 10},
            {'9', 9},
            {'8', 8},
            {'7', 7},
            {'6', 6},
            {'5', 5},
            {'4', 4},
            {'3', 3},
            {'2', 2}
        };
    
        List<string> lines = File.ReadLines("full_input.txt").ToList();
        List<List<string>> allGames = ParseInput(lines);
        var sortedGames = allGames.
                            Select(g => new {
                                Game = g,
                                FirstVal = cardValues[g[0][0]],
                                SecondVal = cardValues[g[0][1]],
                                ThirdVal = cardValues[g[0][2]],
                                FourthVal = cardValues[g[0][3]],
                                FifthVal = cardValues[g[0][4]],
                            })
                            .OrderByDescending(x => SortByType(x.Game))
                            .ThenBy(x => x.FirstVal)
                            .ThenBy(x => x.SecondVal)
                            .ThenBy(x => x.ThirdVal)
                            .ThenBy(x => x.FourthVal)
                            .ThenBy(x => x.FifthVal)
                            .Select(x => x.Game);

        long sum = 0;
        long rank = 2;

        foreach (List<string> game in sortedGames)
        {   
            Console.WriteLine(game[0]);
            if (sum == 0)
                {
                    sum += Int32.Parse(game[1]);
                }
            else
                {
                    sum += rank * Int32.Parse(game[1]);
                    rank ++;
                }
        }
        Console.WriteLine(sum);
    }
}