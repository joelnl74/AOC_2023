using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC
{
    public static class AOCUtilities
    {
        public static Tuple<char[,], int, int> ParseFileToArray()
        {
            char[,] array;
            var lines = File.ReadAllLines("../../../Resources/aoc.txt");

            var width = lines[0].Length;
            var height = lines.Length;

            array = new char[width, height];

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    array[i, j] = lines[i][j];
                }
            }

            return Tuple.Create(array, width, height);
        }

        public static void Print(char[,] array, int width, int heigth)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    Console.Write(array[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
