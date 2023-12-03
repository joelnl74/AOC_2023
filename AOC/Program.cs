// See https://aka.ms/new-console-template for more information

int total = 0;
const int minCharacters = 3;
const int maxCharacters = 5;

Dictionary<string, int> map = new Dictionary<string, int>
{
    {"one", 1 },
    {"two", 2 },
    {"three", 3 },
    {"four", 4 },
    {"five", 5 },
    {"six", 6 },
    {"seven", 7 },
    {"eight", 8 },
    {"nine", 9 },
};

int CheckCharacter(string value, int index)
{
    var characrter = value.ElementAt(index);
    var isNumber = Char.IsNumber(characrter);

    if (isNumber)
    {
        return int.Parse(characrter.ToString());
    }

    if (index + 3 > value.Length)
    {
        return -1;
    }

    for (var i = minCharacters; i <= maxCharacters; i++)
    {
        var subString = index + i - 1 < value.Length ? value.Substring(index, i) : "";
        var contains = map.ContainsKey(subString);

        if (contains)
        {
            return map[subString];
        }
    }

    return -1;
}

foreach (string line in File.ReadLines("../../../Resources/aoc.txt"))
{
    int leftMost = -1;
    int rightMost = -1;
    
    for (var i = 0; i < line.Length; i++)
    {
        var number = CheckCharacter(line, i);

        if (number == -1)
        {
            continue;
        }

        if (leftMost == -1)
        {
            leftMost = number;
        }

        rightMost = number;
    }

    Console.WriteLine($"{leftMost}, {rightMost}");

    string value = leftMost.ToString() + rightMost.ToString();

    total += int.Parse(value);
}


Console.WriteLine(total);
