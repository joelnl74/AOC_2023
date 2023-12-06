using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC
{
    public class Part1
    {
        public Part1()
        {
            const long MapGroupCount = 7;

            using var inputStream = File.OpenRead("../../../Resources/aoc.txt");
            using var reader = new StreamReader(inputStream);

            var seedsLine = reader.ReadLine()!.Substring("seeds:".Length);
            var seeds = seedsLine.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(long.Parse)
                .ToArray();

            reader.ReadLine();

            for (long i = 0; i < MapGroupCount; i++)
            {
                // Header line x -> y
                reader.ReadLine();

                var seedRanges = new List<Seed>();
                string? line = reader.ReadLine();

                while (string.IsNullOrEmpty(line) == false)
                {
                    var parts = line.Split(' ').Select(long.Parse).ToArray();
                    seedRanges.Add(new Seed(parts[0], parts[1], parts[2]));
                    line = reader.ReadLine();
                }

                var seedRangeGroup = new SeedRangeGroup(seedRanges.ToArray());

                for (long j = 0; j < seeds.Length; j++)
                {
                    seeds[j] = seedRangeGroup.Map(seeds[j]);
                }
            }

            Console.WriteLine(seeds.Min());
        }
    }
}
