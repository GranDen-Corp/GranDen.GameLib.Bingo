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
        public MarkPoint2D(int x, int y, bool marked) : base((x, y))
        {
            Marked = marked;
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
        /// Init a MarkPoint2D object using base class object and a boolean value to indicate marked or not
        /// </summary>
        /// <param name="point2D"></param>
        /// <param name="marked"></param>
        public MarkPoint2D(IntPoint2D point2D, bool marked) : base(point2D.X, point2D.Y)
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