namespace GranDen.GameLib.Bingo.Coordinates
{
    /// <summary>
    /// Base class for describe (X, Y) coordinate point.
    /// </summary>
    public class IntPoint2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public IntPoint2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IntPoint2D((int, int) pointTuple)
        {
            var (x, y) = pointTuple;
            X = x;
            Y = y;
        }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}