using System.Collections.Generic;
using System.Linq;
using GranDen.GameLib.Bingo.Coordinates;

namespace GranDen.GameLib.Bingo
{
    /// <summary>
    /// 2D Bingo Line Prize
    /// </summary>
    public class PrizeLine2D
    {
        /// <summary>
        /// Bingo prize identifier
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Bingo prize line points
        /// </summary>
        public IReadOnlyList<IntPoint2D> Points { get; }

        /// <summary>
        /// Create a bingo prize using a name identifier and (x, y) tuple list
        /// </summary>
        /// <param name="matchedPoints"></param>
        /// <param name="prizeName"></param>
        public PrizeLine2D(IEnumerable<(int X, int Y)> matchedPoints, string prizeName)
        {
            Points = matchedPoints.Select(m => new IntPoint2D(m.X, m.Y)).ToList();
            Name = prizeName;
        }
    }
}
