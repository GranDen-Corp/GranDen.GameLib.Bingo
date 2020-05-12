using System;
using System.Collections.Generic;
using System.Linq;
using GranDen.GameLib.Bingo.Coordinates;

namespace GranDen.GameLib.Bingo
{
    public class PrizeLine2D
    {
        public string Name { get; }

        public IReadOnlyList<IntPoint2D> Points { get; }

        public PrizeLine2D(IEnumerable<(int X, int Y)> matchedPoints, string prizeName)
        {
            Points = matchedPoints.Select(m => new IntPoint2D(m.X, m.Y)).ToList();
            Name = prizeName;
        }
    }
}
