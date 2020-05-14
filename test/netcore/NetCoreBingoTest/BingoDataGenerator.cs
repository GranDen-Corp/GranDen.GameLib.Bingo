using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GranDen.GameLib.Bingo;

namespace NetCoreBingoTest
{
    public class Normal4X4_BingoPrizRReData
    {
        public static IEnumerable<object[]> HorizontalPrize => new List<object[]>
        {
            new object[] { _horizontalPrize }
        };

        public static IEnumerable<object[]> VerticalPrize => new List<object[]>
        {
            new object[] { _verticalPrize }
        };

        public static IEnumerable<object[]> DiagonalPrize => new List<object[]>
        {
            new object[] { _diagonalPrize }
        };

        public static IEnumerable<object> AllPrize
        {
            get
            {
                var all = new List<PrizeLine2D>(_horizontalPrize.Count + _verticalPrize.Count + _diagonalPrize.Count);
                all.AddRange(_horizontalPrize);
                all.AddRange(_verticalPrize);
                all.AddRange(_diagonalPrize);

                return new object[] { all };
            }
        }

        private static List<PrizeLine2D> _horizontalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)>{(0,0), (1,0), (2,0), (3,0)},"Horizontal Line1"),
            new PrizeLine2D(new List<(int X, int Y)>{(0,1), (1,1), (2,1), (3,1)},"Horizontal Line2"),
            new PrizeLine2D(new List<(int X, int Y)>{(0,2), (1,2), (2,2), (3,2)},"Horizontal Line3"),
            new PrizeLine2D(new List<(int X, int Y)>{(0,3), (1,3), (2,3), (3,3)},"Horizontal Line4"),
        };

        private static List<PrizeLine2D> _verticalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)>{(0,0), (0,1), (0,2), (0,3)},"Vertical Line1"),
            new PrizeLine2D(new List<(int X, int Y)>{(1,0), (1,1), (1,2), (1,3)},"Vertical Line2"),
            new PrizeLine2D(new List<(int X, int Y)>{(2,0), (2,1), (2,2), (2,3)},"Vertical Line3"),
            new PrizeLine2D(new List<(int X, int Y)>{(3,0), (3,1), (3,2), (3,3)},"Vertical Line4"),
        };

        private static List<PrizeLine2D> _diagonalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)>{(0,0), (1,1), (2,2), (3,3)},"Diagonal Line1"),
            new PrizeLine2D(new List<(int X, int Y)>{(3,0), (2,1), (1,2), (0,3)},"Diagonal Line2"),
        };
    }
}