// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Console.WriteLine("Hello world");

int totalPoints = 0;
int played = 0;

foreach(string line in File.ReadLines("../../../Resources/aoc.txt"))
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