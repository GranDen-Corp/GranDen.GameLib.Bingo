﻿using System.Collections.Generic;
using System.Linq;
using GranDen.GameLib.Bingo;
using Xunit;

namespace Net6BingoTest
{
    public class Struct5x5Point2dTest
    {
        [Fact]
        public void TestNoPrizeLine()
        {
            //Arrange
            var bingo = new Bingo2dPrizeClincher<MyPrize>(new List<PrizeLine2D<MyPrize>>());
            var markedPoints =
                new List<MarkPoint2D>().AddMarkPoint2Ds(
                    new MarkPoint2D((0, 0)), new MarkPoint2D((0, 1)),
                    new MarkPoint2D((1, 1)), new MarkPoint2D((2, 1)));

            //Act
            var matchedPrizes = bingo.Decide(markedPoints);

            //Assert
            Assert.Empty(matchedPrizes);
        }

        [Fact]
        public void TestAllPrizeLine()
        {
            //Arrange
            var allPrize = _horizontalPrize.Concat(_verticalPrize).Concat(_diagonalPrize).ToList();
            var bingo = new Bingo2dPrizeClincher<MyPrize>(allPrize);
            var markedPoints =
                new List<MarkPoint2D>().AddMarkPoint2Ds(
                    (0, 0, true), (1, 0, true), (2, 0, true), (3, 0, true), (4, 0, true),
                    (0, 1, true), (1, 1, true), (2, 1, true), (3, 1, true), (4, 1, true),
                    (0, 2, true), (1, 2, true), (2, 2, true), (3, 2, true), (4, 2, true),
                    (0, 3, true), (1, 3, true), (2, 3, true), (3, 3, true), (4, 3, true),
                    (0, 4, true), (1, 4, true), (2, 4, true), (3, 4, true), (4, 4, true)
                );

            //Act
            var matchedPrizes = bingo.Decide(markedPoints);

            //Assert
            Assert.True(matchedPrizes.Count == allPrize.Count);
            Assert.Collection(matchedPrizes,
                m => Assert.Equal(allPrize[0].Prize, m),
                m => Assert.Equal(allPrize[1].Prize, m),
                m => Assert.Equal(allPrize[2].Prize, m),
                m => Assert.Equal(allPrize[3].Prize, m),
                m => Assert.Equal(allPrize[4].Prize, m),
                m => Assert.Equal(allPrize[5].Prize, m),
                m => Assert.Equal(allPrize[6].Prize, m),
                m => Assert.Equal(allPrize[7].Prize, m),
                m => Assert.Equal(allPrize[8].Prize, m),
                m => Assert.Equal(allPrize[9].Prize, m),
                m => Assert.Equal(allPrize[10].Prize, m),
                m => Assert.Equal(allPrize[11].Prize, m));
        }

        [Fact]
        public void TestOnlyDiagonalPrizeLine()
        {
            //Arrange
            var allPrizes = _horizontalPrize.Concat(_verticalPrize).Concat(_diagonalPrize).ToArray();
            var bingo = new Bingo2dPrizeClincher<MyPrize>(allPrizes);
            var markedPoints = System.Array.Empty<MarkPoint2D>().AddMarkPoint2Ds(
                (0, 0, true), (1, 0, true),
                (0, 1, false), (1, 1, true), (2, 1, true),
                (0, 2, false), (1, 2, false), (2, 2, true),
                (0, 3, false), (1, 3, false), (2, 3, false), (3, 3, true),
                (0, 4, false), (1, 4, false), (2, 4, false), (3, 4, false), (4, 4, true)
            );

            //Act
            var matchedPrizes = bingo.Decide(markedPoints);

            //Assert
            var myPrizes = matchedPrizes as MyPrize[] ?? matchedPrizes.ToArray();
            Assert.True(myPrizes.Length == 1);
            Assert.Collection(myPrizes,
                m => Assert.Equal(allPrizes[10].Prize, m));
        }

        #region Helper Class and Properties

        private struct MyPrize
        {
            public string Name { get; set; }
        }

        private static IEnumerable<PrizeLine2D<MyPrize>> _horizontalPrize => new List<PrizeLine2D<MyPrize>>
        {
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (0, 0),
                    (1, 0),
                    (2, 0),
                    (3, 0),
                    (4, 0)
                },
                new MyPrize {Name = "Horizontal Line1"}),
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (0, 1),
                    (1, 1),
                    (2, 1),
                    (3, 1),
                    (4, 1)
                },
                new MyPrize {Name = "Horizontal Line2"}),
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (0, 2),
                    (1, 2),
                    (2, 2),
                    (3, 2),
                    (4, 2)
                },
                new MyPrize {Name = "Horizontal Line3"}),
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (0, 3),
                    (1, 3),
                    (2, 3),
                    (3, 3),
                    (4, 3)
                },
                new MyPrize {Name = "Horizontal Line4"}),
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (0, 4),
                    (1, 4),
                    (2, 4),
                    (3, 4),
                    (4, 4)
                },
                new MyPrize {Name = "Horizontal Line5"}),
        };

        private static IEnumerable<PrizeLine2D<MyPrize>> _verticalPrize => new List<PrizeLine2D<MyPrize>>
        {
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (0, 0),
                    (0, 1),
                    (0, 2),
                    (0, 3),
                    (0, 4)
                },
                new MyPrize {Name = "Vertical Line1"}),
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (1, 0),
                    (1, 1),
                    (1, 2),
                    (1, 3),
                    (1, 4)
                },
                new MyPrize {Name = "Vertical Line2"}),
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (2, 0),
                    (2, 1),
                    (2, 2),
                    (2, 3),
                    (2, 4)
                },
                new MyPrize {Name = "Vertical Line3"}),
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (3, 0),
                    (3, 1),
                    (3, 2),
                    (3, 3),
                    (3, 4)
                },
                new MyPrize {Name = "Vertical Line4"}),
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (4, 0),
                    (4, 1),
                    (4, 2),
                    (4, 3),
                    (4, 4)
                },
                new MyPrize {Name = "Vertical Line5"}),
        };

        private static IEnumerable<PrizeLine2D<MyPrize>> _diagonalPrize => new List<PrizeLine2D<MyPrize>>
        {
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (0, 0),
                    (1, 1),
                    (2, 2),
                    (3, 3),
                    (4, 4)
                },
                new MyPrize {Name = "Diagonal Line1"}),
            new PrizeLine2D<MyPrize>(new List<(int X, int Y)>
                {
                    (4, 0),
                    (3, 1),
                    (2, 2),
                    (1, 3),
                    (0, 4)
                },
                new MyPrize {Name = "Diagonal Line2"}),
        };

        #endregion
    }
}
