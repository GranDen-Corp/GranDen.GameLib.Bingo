using System;
using System.Linq;
using GranDen.GameLib.Bingo.Coordinates;

namespace GranDen.GameLib.Bingo
{
    /// <summary>
    /// 2D Input MarkPoint
    /// </summary>
    public class MarkPoint2D : IntPoint2D
    {
        /// <summary>
        /// Is this point being marked or not
        /// </summary>
        public bool Marked { get; set; }

        /// <summary>
        /// Init a MarkPoint2D object using primitive arguments
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="marked"></param>
        public MarkPoint2D(int x, int y, bool marked = true) : base((x, y))
        {
            Marked = marked;
        }

        /// <summary>
        /// class constructor by giving "(x, y | true )" or "x , y | true" representation string
        /// </summary>
        /// <param name="markPoint2dString"></param>
        public MarkPoint2D(string markPoint2dString) : base(FetchIntPoint2DRawString(markPoint2dString))
        {
            var marked_separator = markPoint2dString.LastIndexOf('|');
            if (marked_separator == -1)
            {
                Marked = true;
            }
            else
            {
                var raw_markedStr = markPoint2dString.Substring(marked_separator)
                    .Split(new[] {'|', ')'}, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();

                Marked = raw_markedStr == null || bool.Parse(raw_markedStr);
            }
        }

        private static string FetchIntPoint2DRawString(string rawString)
        {
            var marked_separator = rawString.LastIndexOf('|');
            return marked_separator == -1 ? rawString : rawString.Substring(0, marked_separator);
        }

        /// <summary>
        /// Init a MarkPoint2D object using (x, y, true|false) tuple
        /// </summary>
        /// <param name="markPointTuple"></param>
        public MarkPoint2D((int x, int y, bool marked) markPointTuple) : base((markPointTuple.x, markPointTuple.y))
        {
            var (_, _, marked) = markPointTuple;
            Marked = marked;
        }

        /// <summary>
        /// Init a MarkPoint2D object using base class object and an optional boolean value to indicate marked or not
        /// </summary>
        /// <param name="point2D"></param>
        /// <param name="marked"></param>
        public MarkPoint2D(IntPoint2D point2D, bool marked = true) : base(point2D.X, point2D.Y)
        {
            Marked = marked;
        }

        /// <summary>
        /// Init a MarkPoint2D object using base class object and an optional boolean value to indicate marked or not
        /// </summary>
        /// <param name="pointTuple"></param>
        /// <param name="marked"></param>
        public MarkPoint2D((int x, int y) pointTuple, bool marked = true) : base(pointTuple.x, pointTuple.y)
        {
            Marked = marked;
        }

        /// <summary>
        /// Tuple deconstruct implementation
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="marked"></param>
        public void Deconstruct(out int x, out int y, out bool marked)
        {
            Deconstruct(out x, out y);
            marked = Marked;
        }
    }
}
