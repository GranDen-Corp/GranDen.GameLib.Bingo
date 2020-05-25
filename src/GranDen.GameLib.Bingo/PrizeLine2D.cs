using System.Collections.Generic;
using System.Linq;
using GranDen.GameLib.Bingo.Coordinates;

namespace GranDen.GameLib.Bingo
{
    /// <summary>
    /// 2D Bingo Line Prize
    /// </summary>
    public class PrizeLine2D : PrizeLine2D<string>
    {
        /// <summary>
        /// Bingo prize identifier
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create a bingo prize using a name identifier and (x, y) tuple list
        /// </summary>
        /// <param name="matchedPoints"></param>
        /// <param name="prizeName"></param>
        public PrizeLine2D(IEnumerable<(int X, int Y)> matchedPoints, string prizeName) : base(matchedPoints, prizeName)
        {
            Name = prizeName;
        }
    }

    /// <summary>
    /// Generic 2D Bingo Line Prize
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PrizeLine2D<T>
    {
        /// <summary>
        /// Bingo prize line points
        /// </summary>
        public IReadOnlyList<IntPoint2D> Points { get; }

        /// <summary>
        /// Create a bingo prize using a typeof T Prize Object and (x, y) tuple list
        /// </summary>
        /// <param name="matchedPoints"></param>
        /// <param name="prizeObj"></param>
        public PrizeLine2D(IEnumerable<(int X, int Y)> matchedPoints, T prizeObj)
        {
            Points = matchedPoints.Select(m => new IntPoint2D(m.X, m.Y)).ToList();
            Prize = prizeObj;
        }

        /// <summary>
        /// Bingo prize
        /// </summary>
        public T Prize { get; }
    }
}