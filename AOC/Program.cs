// See https://aka.ms/new-console-template for more information
// string line in File.ReadLines("../../../Resources/aoc.txt"

using AOC;
using System.Diagnostics;

List<Game> gamesPlayed = new List<Game>();

Main();

int Main()
{
    int index = 1;
    int green = 0;
    int blue = 0;
    int red = 0;
    string value = "";
    bool checkingNumber = false;

    foreach (string line in File.ReadLines("../../../Resources/aoc.txt"))
    {
        red = 0;
        blue = 0;
        green = 0;
        
        for (int i = 8; i < line.Length; i++)
        {
            var isNumber = Char.IsNumber(line[i]);
        
            if (isNumber)
            {
                checkingNumber = true;
                value += line[i];
            }

            if (checkingNumber == true && isNumber == false)
            {
                checkingNumber = false;
                
                // Indicates the color with r g b.
                var charachterColor = line[i + 1];
                Update(charachterColor, ref red, ref green, ref blue, int.Parse(value.ToString()));
                value = "";
            }
        }

        gamesPlayed.Add(new Game(index, red, green, blue));
        index++;
    }

    int total = 0;
    Game[] validGames = gamesPlayed.Where(x => x.IsValid).ToArray();

    for (int i = 0; i < gamesPlayed.Count; i++)
    {
        Game game = gamesPlayed[i];
        int productOfRGB = game.Red * game.Green * game.Blue;

        total += productOfRGB;
    }    

    Console.WriteLine(validGames.Sum(y => y.Id));
    Console.WriteLine(total);

    return 1;
}

void Update(char color, ref int r, ref int g, ref int b, int value)
{
    switch (color)
    {
        case 'r':
            r = value > r ? value : r;
            break;
        case 'g':
            g = value > g ? value : g;
            break;
        case 'b':
            b = value > b ? value : b;
            break;
    }
}
