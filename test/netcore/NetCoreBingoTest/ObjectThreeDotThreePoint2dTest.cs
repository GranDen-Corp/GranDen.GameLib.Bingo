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
            var bingo = new Bingo2dPrizeClincher<TestPrize>(new List<PrizeLine2D<TestPrize>>());

            //Act
            var matchedPrizes = bingo.Decide(new List<MarkPoint2D>());

            //Assert
            Assert.Empty(matchedPrizes);
        }

        [Fact]
        public void TestShouldGetHorizontalPrize()
        {
            //Arrange
            List<MarkPoint2D> test1StRowData = _marked1StRowData;
            List<MarkPoint2D> test2NdRowData = _marked2NdRowData;
            List<MarkPoint2D> test3RdRowData = _marked3RdRowData;
            List<MarkPoint2D> testAllRowData = test1StRowData.Concat(test2NdRowData).Concat(test3RdRowData).ToList();
            var bingo = new Bingo2dPrizeClincher<TestPrize>(_horizontalPrize);

            //Act
            var match1 = bingo.Decide(test1StRowData);
            var match2 = bingo.Decide(test2NdRowData);
            var match3 = bingo.Decide(test3RdRowData);
            var matchAll = bingo.Decide(testAllRowData);

            //Assert
            Assert.NotEmpty(match1);
            var prize1 = _horizontalPrize[0].Prize;
            Assert.Equal(prize1, match1[0]);

            Assert.NotEmpty(match2);
            var prize2 = _horizontalPrize[1].Prize;
            Assert.Equal(prize2, match2[0]);

            Assert.NotEmpty(match3);
            var prize3 = _horizontalPrize[2].Prize;
            Assert.Equal(prize3, match3[0]);


            Assert.Collection(matchAll,
                m1 => Assert.Equal(prize1, m1),
                m2 => Assert.Equal(prize2, m2),
                m3 => Assert.Equal(prize3, m3));
        }

        #region Helper Class and Properties

        private class TestPrize
        {
            public string PrizeName { get; set; }
            public uint PrizeValue { get; set; }

            public override bool Equals(object obj)
            {
                return obj is TestPrize input && Equals(input);
            }

            private bool Equals(TestPrize other)
            {
                return PrizeName == other.PrizeName && PrizeValue == other.PrizeValue;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(PrizeName, PrizeValue);
            }
        }

        private static List<PrizeLine2D<TestPrize>> _horizontalPrize => new List<PrizeLine2D<TestPrize>>
        {
            new PrizeLine2D<TestPrize>(new List<(int X, int Y)> {(0, 0), (1, 0), (2, 0)},
                new TestPrize {PrizeName = "Horizontal_Line1", PrizeValue = 101}),
            new PrizeLine2D<TestPrize>(new List<(int X, int Y)> {(0, 1), (1, 1), (2, 1)},
                new TestPrize {PrizeName = "Horizontal_Line2", PrizeValue = 102}),
            new PrizeLine2D<TestPrize>(new List<(int X, int Y)> {(0, 2), (1, 2), (2, 2)},
                new TestPrize {PrizeName = "Horizontal_Line3", PrizeValue = 103})
        };

        private static List<PrizeLine2D<TestPrize>> _verticalPrize => new List<PrizeLine2D<TestPrize>>
        {
            new PrizeLine2D<TestPrize>(new List<(int X, int Y)> {(0, 0), (0, 1), (0, 2)},
                new TestPrize {PrizeName = "Vertical_Line1", PrizeValue = 201}),
            new PrizeLine2D<TestPrize>(new List<(int X, int Y)> {(1, 0), (1, 1), (1, 2)},
                new TestPrize {PrizeName = "Vertical_Line2", PrizeValue = 202}),
            new PrizeLine2D<TestPrize>(new List<(int X, int Y)> {(2, 0), (2, 1), (2, 2)},
                new TestPrize {PrizeName = "Vertical_Line3", PrizeValue = 203})
        };

        private static List<PrizeLine2D<TestPrize>> _diagonalPrize => new List<PrizeLine2D<TestPrize>>
        {
            new PrizeLine2D<TestPrize>(new List<(int X, int Y)> {(0, 0), (1, 1), (2, 2)},
                new TestPrize {PrizeName = "Diagonal_Line1", PrizeValue = 301}),
            new PrizeLine2D<TestPrize>(new List<(int X, int Y)> {(3, 0), (2, 1), (1, 2)},
                new TestPrize {PrizeName = "Diagonal_Line1", PrizeValue = 302}),
        };

        private static List<PrizeLine2D<TestPrize>> _allPrize => _horizontalPrize.Concat(_horizontalPrize)
            .Concat(_verticalPrize).Concat(_diagonalPrize).ToList();


        private readonly List<MarkPoint2D> _marked1StRowData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 0, true),
            new MarkPoint2D(1, 0, true),
            new MarkPoint2D(2, 0, true)
        };

        private readonly List<MarkPoint2D> _marked2NdRowData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 1, true),
            new MarkPoint2D(1, 1, true),
            new MarkPoint2D(2, 1, true)
        };

        private readonly List<MarkPoint2D> _marked3RdRowData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 2, true),
            new MarkPoint2D(1, 2, true),
            new MarkPoint2D(2, 2, true)
        };

        private readonly List<MarkPoint2D> _marked4ThRowData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 3, true),
            new MarkPoint2D(1, 3, true),
            new MarkPoint2D(2, 3, true)
        };

        private readonly List<MarkPoint2D> _marked1StColData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 0, true),
            new MarkPoint2D(0, 1, true),
            new MarkPoint2D(0, 2, true)
        };

        private readonly List<MarkPoint2D> _marked2NdColData = new List<MarkPoint2D>
        {
            new MarkPoint2D(1, 0, true),
            new MarkPoint2D(1, 1, true),
            new MarkPoint2D(1, 2, true)
        };

        private readonly List<MarkPoint2D> _marked3rdColData = new List<MarkPoint2D>
        {
            new MarkPoint2D(2, 0, true),
            new MarkPoint2D(2, 1, true),
            new MarkPoint2D(2, 2, true)
        };

        private readonly List<MarkPoint2D> _marked4thColData = new List<MarkPoint2D>
        {
            new MarkPoint2D(3, 0, true),
            new MarkPoint2D(3, 1, true),
            new MarkPoint2D(3, 2, true)
        };

        private readonly List<MarkPoint2D> _markedSlashDiagonalData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 0, true),
            new MarkPoint2D(1, 1, true),
            new MarkPoint2D(2, 2, true)
        };

        private readonly List<MarkPoint2D> _markedBackSlashDiagonalData = new List<MarkPoint2D>
        {
            new MarkPoint2D(3, 0, true),
            new MarkPoint2D(2, 1, true),
            new MarkPoint2D(1, 2, true)
        };

        #endregion
    }
}