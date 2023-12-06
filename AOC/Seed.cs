using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC
{
    class SeedRangeGroup
    {
        private readonly Seed[] _seedRanges;

        public SeedRangeGroup(Seed[] seedRanges)
        {
            _seedRanges = seedRanges;
        }

        public long Map(long value)
        {
            foreach (var range in _seedRanges)
            {
                if (range.IsInSourceRange(value))
                {
                    return range.MapSource(value);
                }
            }

            return value;
        }
    }

    public class Seed
    {
        private readonly long _destinationStart;
        private readonly long _sourceStart;
        private readonly long _rangeLength;

        public Seed(long destinationStart, long sourceStart, long rangeLength)
        {
            _destinationStart = destinationStart;
            _sourceStart = sourceStart;
            _rangeLength = rangeLength;
        }

        public bool IsInSourceRange(long value) =>
            value >= _sourceStart &&
            value < (_sourceStart + _rangeLength);

        public long MapSource(long value) =>
            _destinationStart + (value - _sourceStart);
    }
}
