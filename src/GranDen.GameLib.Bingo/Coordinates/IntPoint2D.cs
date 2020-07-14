using System;
using System.Linq;

namespace GranDen.GameLib.Bingo.Coordinates
{
    /// <summary>
    /// Base class for describe (X, Y) coordinate point.
    /// </summary>
    public class IntPoint2D
    {
        /// <summary>
        /// X coordinate (horizontal)
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate (vertical)
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// class constructor by giving x, y coordinate values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public IntPoint2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// class constructor by giving (x, y) tuple
        /// </summary>
        /// <param name="pointTuple"></param>
        public IntPoint2D((int, int) pointTuple)
        {
            var (x, y) = pointTuple;
            X = x;
            Y = y;
        }

        /// <summary>
        /// class constructor by giving "(x, y)" or "x , y" representation string
        /// </summary>
        /// <param name="tupleString"></param>
        public IntPoint2D(string tupleString)
        {
            var values = tupleString.Split(new[] {'(', ',', ')'}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())
                .ToArray();
            X = int.Parse(values[0]);
            Y = int.Parse(values[1]);
        }

        /// <summary>
        /// Tuple deconstruct implementation
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}
