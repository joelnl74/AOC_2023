namespace AOC
{
    public class PartTwo
    {
        char[,] array;

        int width = 0;
        int height = 0;
        int sum = 0;
        int combined = 0;
        int count = 0;

        public PartTwo()
        {
            Main();
        }

        void Main()
        {
            var tuple = AOCUtilities.ParseFileToArray();
            array = tuple.Item1;
            width = tuple.Item2;
            height = tuple.Item3;

            for (int i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var character = array[i, j];
                    var isValidCharacter = character == '*';

                    if (isValidCharacter == false)
                    {
                        continue;
                    }

                    var coordinates = new HashSet<int>();
                    count = 0;
                    combined = 0;
                    
                    CheckCharacter(i + 1, j, ref coordinates);
                    CheckCharacter(i, j + 1, ref coordinates);
                    CheckCharacter(i - 1, j, ref coordinates);
                    CheckCharacter(i, j - 1, ref coordinates);
                    CheckCharacter(i + 1, j + 1, ref coordinates);
                    CheckCharacter(i + 1, j - 1, ref coordinates);
                    CheckCharacter(i - 1, j + 1, ref coordinates);
                    CheckCharacter(i - 1, j - 1, ref coordinates);

                    if (count == 2)
                    {
                        sum += combined;
                    }
                }
            }

            Console.WriteLine(sum.ToString());
        }

        int CheckCharacter(int x, int y, ref HashSet<int> checkedCoordinates)
        {
            if (x >= width || y >= height || x < 0 || y < 0)
            {
                return 0;
            }

            var coordinate = width * x + y;
            var value = array[x, y];

            if (checkedCoordinates.Contains(coordinate))
            {
                return 0;
            }

            checkedCoordinates.Add(width * x + y);

            if (Char.IsNumber(value) == false)
            {
                return 0;
            }

            string number = array[x, y].ToString();

            // Get number.
            for (var i = y - 1; i >= 0; i--)
            {
                var character = array[x, i];

                if (Char.IsNumber(character))
                {
                    checkedCoordinates.Add(width * x + i);
                    number = number.Insert(0, character.ToString());
                    continue;
                }

                break;
            }

            for (var i = y + 1; i < width; i++)
            {
                var character = array[x, i];

                if (Char.IsNumber(character))
                {
                    checkedCoordinates.Add(width * x + i);
                    number += character;
                    continue;
                }

                break;
            }

            var parsedNumber = int.Parse(number);


            if (count == 0)
            {
                combined += parsedNumber;
                count++;
                return parsedNumber;
            }

            combined *= parsedNumber;
            count++;

            return parsedNumber;
        }
    }
}
