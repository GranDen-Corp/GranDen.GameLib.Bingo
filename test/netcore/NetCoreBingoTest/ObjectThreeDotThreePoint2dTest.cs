using System;
using System.Collections.Generic;
using System.Linq;
using GranDen.GameLib.Bingo;
using Xunit;

namespace NetCoreBingoTest
{
    public class ObjectThreeDotThreePoint2dTest
    {
        [Fact]
        public void TestNoPrizeLine()
        {
            //Arrange
            var bingo = new Bingo2dPrizeClincher<DemoPrize>(new List<PrizeLine2D<DemoPrize>>());

            //Act
            var matchedPrizes = bingo.Decide(new List<MarkPoint2D>());

            //Assert
            Assert.Empty(matchedPrizes);
        }

        [Fact]
        public void TestShouldGetHorizontalPrize()
        {
            //Arrange
            var test1StRowData = _marked1StRowData;
            var test2NdRowData = _marked2NdRowData;
            var test3RdRowData = _marked3RdRowData;
            var testAllRowData = test1StRowData.Union(test2NdRowData).Union(test3RdRowData).ToList();
            var bingo = new Bingo2dPrizeClincher<DemoPrize>(_horizontalPrize);

            //Act
            var match1 = bingo.Decide(test1StRowData);
            var match2 = bingo.Decide(test2NdRowData);
            var match3 = bingo.Decide(test3RdRowData);
            var matchAll = bingo.Decide(testAllRowData);

            //Assert
            Assert.True(match1.Count == 1);
            var prize1 = _horizontalPrize[0].Prize;
            Assert.Collection(match1, m1 => Assert.Equal(prize1, m1));


            Assert.True(match2.Count == 1);
            var prize2 = _horizontalPrize[1].Prize;
            Assert.Collection(match2, m1 => Assert.Equal(prize2, m1));

            Assert.True(match3.Count == 1);
            var prize3 = _horizontalPrize[2].Prize;
            Assert.Collection(match3, m1 => Assert.Equal(prize3, m1));

            Assert.True(matchAll.Count == 3);
            Assert.Collection(matchAll,
                m1 => Assert.Equal(prize1, m1),
                m2 => Assert.Equal(prize2, m2),
                m3 => Assert.Equal(prize3, m3));
        }

        [Fact]
        public void TestShouldGetVerticalPrize()
        {
            //Arrange
            var test1StColData = _marked1StColData;
            var test2NdColData = _marked2NdColData;
            var test3RdColData = _marked3rdColData;
            var testAllColData = test1StColData.Union(test2NdColData).Union(test3RdColData).ToList();
            var bingo = new Bingo2dPrizeClincher<DemoPrize>(_verticalPrize);

            //Act
            var match1 = bingo.Decide(test1StColData);
            var match2 = bingo.Decide(test2NdColData);
            var match3 = bingo.Decide(test3RdColData);
            var matchAll = bingo.Decide(testAllColData);

            //Assert
            Assert.True(match1.Count == 1);
            var prize1 = _verticalPrize[0].Prize;
            Assert.Collection(match1, m1 => Assert.Equal(prize1, m1));

            Assert.True(match2.Count == 1);
            var prize2 = _verticalPrize[1].Prize;
            Assert.Collection(match2, m1 => Assert.Equal(prize2, m1));

            Assert.True(match3.Count == 1);
            var prize3 = _verticalPrize[2].Prize;
            Assert.Collection(match3, m1 => Assert.Equal(prize3, m1));

            Assert.True(matchAll.Count == 3);
            Assert.Collection(matchAll,
                m1 => Assert.Equal(prize1, m1),
                m2 => Assert.Equal(prize2, m2),
                m3 => Assert.Equal(prize3, m3));
        }

        [Fact]
        public void TestShouldGetDiagonalPrize()
        {
            //Arrange
            var test1DiagonalData = _markedSlashDiagonalData;
            var test2DiagonalData = _markedBackSlashDiagonalData;
            var testAllDiagonalData = test1DiagonalData.Union(test2DiagonalData).ToList();
            var bingo = new Bingo2dPrizeClincher<DemoPrize>(_diagonalPrize);

            //Act
            var match1 = bingo.Decide(test1DiagonalData);
            var match2 = bingo.Decide(test2DiagonalData);
            var matchAll = bingo.Decide(testAllDiagonalData);

            //Assert
            Assert.True(match1.Count == 1);
            var prize1 = _diagonalPrize[0].Prize;
            Assert.Collection(match1, m1 => Assert.Equal(prize1, m1));

            Assert.True(match1.Count == 1);
            var prize2 = _diagonalPrize[1].Prize;
            Assert.Collection(match2, m1 => Assert.Equal(prize2, m1));

            Assert.True(matchAll.Count == 2);
            Assert.Collection(matchAll,
                m1 => Assert.Equal(prize1, m1),
                m2 => Assert.Equal(prize2, m2));
        }

        #region Helper Class and Properties

        private class DemoPrize
        {
            public string PrizeName { get; set; }
            public uint PrizeValue { get; set; }

            public override bool Equals(object obj)
            {
                return obj is DemoPrize input && Equals(input);
            }

            private bool Equals(DemoPrize other)
            {
                return PrizeName == other.PrizeName && PrizeValue == other.PrizeValue;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(PrizeName, PrizeValue);
            }
        }

        private static List<PrizeLine2D<DemoPrize>> _horizontalPrize => new List<PrizeLine2D<DemoPrize>>
        {
            new PrizeLine2D<DemoPrize>(new List<(int X, int Y)> {(0, 0), (1, 0), (2, 0)},
                new DemoPrize {PrizeName = "Horizontal_Line1", PrizeValue = 101}),
            new PrizeLine2D<DemoPrize>(new List<(int X, int Y)> {(0, 1), (1, 1), (2, 1)},
                new DemoPrize {PrizeName = "Horizontal_Line2", PrizeValue = 102}),
            new PrizeLine2D<DemoPrize>(new List<(int X, int Y)> {(0, 2), (1, 2), (2, 2)},
                new DemoPrize {PrizeName = "Horizontal_Line3", PrizeValue = 103})
        };

        private static List<PrizeLine2D<DemoPrize>> _verticalPrize => new List<PrizeLine2D<DemoPrize>>
        {
            new PrizeLine2D<DemoPrize>(new List<(int X, int Y)> {(0, 0), (0, 1), (0, 2)},
                new DemoPrize {PrizeName = "Vertical_Line1", PrizeValue = 201}),
            new PrizeLine2D<DemoPrize>(new List<(int X, int Y)> {(1, 0), (1, 1), (1, 2)},
                new DemoPrize {PrizeName = "Vertical_Line2", PrizeValue = 202}),
            new PrizeLine2D<DemoPrize>(new List<(int X, int Y)> {(2, 0), (2, 1), (2, 2)},
                new DemoPrize {PrizeName = "Vertical_Line3", PrizeValue = 203})
        };

        private static List<PrizeLine2D<DemoPrize>> _diagonalPrize => new List<PrizeLine2D<DemoPrize>>
        {
            new PrizeLine2D<DemoPrize>(new List<(int X, int Y)> {(0, 0), (1, 1), (2, 2)},
                new DemoPrize {PrizeName = "Diagonal_Line1", PrizeValue = 301}),
            new PrizeLine2D<DemoPrize>(new List<(int X, int Y)> {(3, 0), (2, 1), (1, 2)},
                new DemoPrize {PrizeName = "Diagonal_Line1", PrizeValue = 302}),
        };

        private static List<PrizeLine2D<DemoPrize>> _allPrize => _horizontalPrize.Concat(_horizontalPrize)
            .Concat(_verticalPrize).Concat(_diagonalPrize).ToList();


        private readonly List<MarkPoint2D> _marked1StRowData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 0 ),
            new MarkPoint2D(1, 0 ),
            new MarkPoint2D(2, 0 )
        };

        private readonly List<MarkPoint2D> _marked2NdRowData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 1),
            new MarkPoint2D(1, 1),
            new MarkPoint2D(2, 1)
        };

        private readonly List<MarkPoint2D> _marked3RdRowData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 2),
            new MarkPoint2D(1, 2),
            new MarkPoint2D(2, 2)
        };

        private readonly List<MarkPoint2D> _marked1StColData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 0),
            new MarkPoint2D(0, 1),
            new MarkPoint2D(0, 2)
        };

        private readonly List<MarkPoint2D> _marked2NdColData = new List<MarkPoint2D>
        {
            new MarkPoint2D(1, 0),
            new MarkPoint2D(1, 1),
            new MarkPoint2D(1, 2)
        };

        private readonly List<MarkPoint2D> _marked3rdColData = new List<MarkPoint2D>
        {
            new MarkPoint2D(2, 0),
            new MarkPoint2D(2, 1),
            new MarkPoint2D(2, 2)
        };

        private readonly List<MarkPoint2D> _markedSlashDiagonalData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 0),
            new MarkPoint2D(1, 1),
            new MarkPoint2D(2, 2)
        };

        private readonly List<MarkPoint2D> _markedBackSlashDiagonalData = new List<MarkPoint2D>
        {
            new MarkPoint2D(3, 0),
            new MarkPoint2D(2, 1),
            new MarkPoint2D(1, 2)
        };

        #endregion
    }
}