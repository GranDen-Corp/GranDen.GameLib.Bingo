using GranDen.GameLib.Bingo.Coordinates;

namespace GranDen.GameLib.Bingo
{
    public class MarkPoint2D : IntPoint2D
    {
        public bool Marked { get; set; }

        public MarkPoint2D(int x, int y, bool marked) : base((x, y))
        {
            Marked = marked;
        }

        public MarkPoint2D((int x, int y, bool marked) markPointTuple) : base((markPointTuple.x, markPointTuple.y))
        {
            var (_, _, marked) = markPointTuple;
            Marked = marked;
        }

        public MarkPoint2D(IntPoint2D point2D, bool marked) : base(point2D.X, point2D.Y)
        {
            Marked = marked;
        }

        public void Deconstruct(out int x, out int y, out bool marked)
        {
            Deconstruct(out x, out y);
            marked = Marked;
        }
    }
}