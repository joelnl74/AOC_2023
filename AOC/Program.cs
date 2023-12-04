// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Part1();
Part2();

void Part1()
{
    int totalPoints = 0;

    foreach (string line in File.ReadLines("../../../Resources/aoc.txt"))
    {
        var ticket = line.Split(':', StringSplitOptions.TrimEntries)[1].Split('|');

        var game1 = ticket[0].Replace("  ", " ").Split(' ').Select(x => x != "" ? int.Parse(x) : -1).ToHashSet();
        var game2 = ticket[1].Replace("  ", " ").Split(' ').Select(x => x != "" ? int.Parse(x) : -1).ToHashSet();

        game1.Remove(-1);
        game2.Remove(-1);

        var intersect = game2.Intersect(game1).ToList();
        totalPoints += (int)Math.Pow(2, (intersect.Count - 1));
    }

    Console.WriteLine($"Total points: {totalPoints}");
}


void Part2()
{
    var input = File.ReadAllText("../../../Resources/aoc.txt");
    var cards = input.Split("\n").Select(ParseCard).ToArray();
    var counts = cards.Select(_ => 1).ToArray();

    for (var i = 0; i < cards.Length; i++)
    {
        var (card, count) = (cards[i], counts[i]);
        for (var j = 0; j < card.matches; j++)
        {
            counts[i + j + 1] += count;
        }
    }

    Console.WriteLine(counts.Sum());
}

// Only the match count is relevant for a card
Card ParseCard(string line)
{
    var parts = line.Split(':', '|');
    var l = from m in Regex.Matches(parts[1], @"\d+") select m.Value;
    var r = from m in Regex.Matches(parts[2], @"\d+") select m.Value;
    return new Card(l.Intersect(r).Count());
}

record Card(int matches);
