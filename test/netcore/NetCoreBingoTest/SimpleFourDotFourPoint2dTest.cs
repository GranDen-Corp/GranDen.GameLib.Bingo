using System.Collections.Generic;
using System.Linq;
using GranDen.GameLib.Bingo;
using Xunit;

namespace NetCoreBingoTest
{
    public class SimplePrizePoint2dTest
    {
        [Fact]
        public void TestNoPrizeLine()
        {
            //Arrange
            var bingo = new Bingo2dPrizeClincher(new List<PrizeLine2D>());

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
            var test4ThRowData = _marked4ThRowData;
            var testAllRowData = test1StRowData.Union(test2NdRowData).Union(test3RdRowData).Union(test4ThRowData)
                .ToList();
            var bingo = new Bingo2dPrizeClincher(_horizontalPrize);

            //Act
            var match1 = bingo.Decide(test1StRowData);
            var match2 = bingo.Decide(test2NdRowData);
            var match3 = bingo.Decide(test3RdRowData);
            var match4 = bingo.Decide(test4ThRowData);
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

            Assert.True(match1.Count == 1);
            var prize4 = _horizontalPrize[3].Prize;
            Assert.Collection(match4, m1 => Assert.Equal(prize4, m1));

            Assert.True(matchAll.Count == 4);
            Assert.Collection(matchAll,
                m1 => Assert.Equal(prize1, m1),
                m2 => Assert.Equal(prize2, m2),
                m3 => Assert.Equal(prize3, m3),
                m4 => Assert.Equal(prize4, m4));
        }

        [Fact]
        public void TestShouldGetVerticalPrize()
        {
            //Arrange
            var test1StColData = _marked1StColData;
            var test2NdColData = _marked2NdColData;
            var test3RdColData = _marked3rdColData;
            var test4ThColData = _marked4thColData;
            var testAllColData = test1StColData.Union(test2NdColData).Union(test3RdColData).Union(test4ThColData)
                .ToList();
            var bingo = new Bingo2dPrizeClincher(_verticalPrize);

            //Act
            var match1 = bingo.Decide(test1StColData);
            var match2 = bingo.Decide(test2NdColData);
            var match3 = bingo.Decide(test3RdColData);
            var match4 = bingo.Decide(test4ThColData);
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

            Assert.True(match1.Count == 1);
            var prize4 = _verticalPrize[3].Prize;
            Assert.Collection(match4, m1 => Assert.Equal(prize4, m1));

            Assert.True(matchAll.Count == 4);
            Assert.Collection(matchAll,
                m1 => Assert.Equal(prize1, m1),
                m2 => Assert.Equal(prize2, m2),
                m3 => Assert.Equal(prize3, m3),
                m4 => Assert.Equal(prize4, m4));
        }

        [Fact]
        public void TestShouldGetDiagonalPrize()
        {
            //Arrange
            var test1DiagonalData = _markedSlashDiagonalData;
            var test2DiagonalData = _markedBackSlashDiagonalData;
            var testAllDiagonalData = test1DiagonalData.Union(test2DiagonalData).ToList();
            var bingo = new Bingo2dPrizeClincher(_diagonalPrize);

            //Act
            var match1 = bingo.Decide(test1DiagonalData);
            var match2 = bingo.Decide(test2DiagonalData);
            var matchAll = bingo.Decide(testAllDiagonalData);

            //Assert
            Assert.True(match1.Count == 1);
            var prize1 = _diagonalPrize[0].Prize;
            Assert.Collection(match1, m1 => Assert.Equal(prize1, m1));

            Assert.True(match2.Count == 1);
            var prize2 = _diagonalPrize[1].Prize;
            Assert.Collection(match2, m1 => Assert.Equal(prize2, m1));

            Assert.True(matchAll.Count == 2);
            Assert.Collection(matchAll,
                m1 => Assert.Equal(prize1, m1),
                m1 => Assert.Equal(prize2, m1));
        }

        #region Helper Class and Properties

        private static List<PrizeLine2D> _horizontalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)> {(0, 0), (1, 0), (2, 0), (3, 0)}, "Horizontal Line1"),
            new PrizeLine2D(new List<(int X, int Y)> {(0, 1), (1, 1), (2, 1), (3, 1)}, "Horizontal Line2"),
            new PrizeLine2D(new List<(int X, int Y)> {(0, 2), (1, 2), (2, 2), (3, 2)}, "Horizontal Line3"),
            new PrizeLine2D(new List<(int X, int Y)> {(0, 3), (1, 3), (2, 3), (3, 3)}, "Horizontal Line4"),
        };

        private static List<PrizeLine2D> _verticalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)> {(0, 0), (0, 1), (0, 2), (0, 3)}, "Vertical Line1"),
            new PrizeLine2D(new List<(int X, int Y)> {(1, 0), (1, 1), (1, 2), (1, 3)}, "Vertical Line2"),
            new PrizeLine2D(new List<(int X, int Y)> {(2, 0), (2, 1), (2, 2), (2, 3)}, "Vertical Line3"),
            new PrizeLine2D(new List<(int X, int Y)> {(3, 0), (3, 1), (3, 2), (3, 3)}, "Vertical Line4"),
        };

        private static List<PrizeLine2D> _diagonalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)> {(0, 0), (1, 1), (2, 2), (3, 3)}, "Diagonal Line1"),
            new PrizeLine2D(new List<(int X, int Y)> {(3, 0), (2, 1), (1, 2), (0, 3)}, "Diagonal Line2"),
        };

        private readonly List<MarkPoint2D> _marked1StRowData =
            new List<MarkPoint2D>().AddMarkPoint2Ds(
                new MarkPoint2D("(0, 0 | true)"), new MarkPoint2D("(1, 0 | true)"), new MarkPoint2D("(2, 0 | true)"), new MarkPoint2D("(3, 0 | true)"));

        private readonly List<MarkPoint2D> _marked2NdRowData =
            new List<MarkPoint2D>().AddMarkPoint2Ds(
                new MarkPoint2D(0, 1), new MarkPoint2D(1, 1), new MarkPoint2D(2, 1), new MarkPoint2D(3, 1));

        private readonly List<MarkPoint2D> _marked3RdRowData =
            new List<MarkPoint2D>().AddMarkPoint2Ds(
                new MarkPoint2D(0, 2), new MarkPoint2D(1, 2), new MarkPoint2D(2, 2), new MarkPoint2D(3, 2));

        private readonly List<MarkPoint2D> _marked4ThRowData =
            new List<MarkPoint2D>().AddMarkPoint2Ds(
                new MarkPoint2D(0, 3), new MarkPoint2D(1, 3), new MarkPoint2D(2, 3), new MarkPoint2D(3, 3));

        private readonly List<MarkPoint2D> _marked1StColData =
            new List<MarkPoint2D>().AddMarkPoint2Ds(
                new MarkPoint2D("0, 0"),
                new MarkPoint2D("0, 1"),
                new MarkPoint2D("0, 2"),
                new MarkPoint2D("0, 3"));

        private readonly List<MarkPoint2D> _marked2NdColData =
            new List<MarkPoint2D>().AddMarkPoint2Ds(
                new MarkPoint2D("1, 0"),
                new MarkPoint2D("1, 1"),
                new MarkPoint2D("1, 2"),
                new MarkPoint2D("1, 3"));

        private readonly List<MarkPoint2D> _marked3rdColData =
            new List<MarkPoint2D>().AddMarkPoint2Ds(
                new MarkPoint2D("2, 0"),
                new MarkPoint2D("2, 1"),
                new MarkPoint2D("2, 2"),
                new MarkPoint2D("2, 3"));

        private readonly List<MarkPoint2D> _marked4thColData =
            new List<MarkPoint2D>().AddMarkPoint2Ds(
                new MarkPoint2D("3, 0"),
                new MarkPoint2D("3, 1"),
                new MarkPoint2D("3, 2"),
                new MarkPoint2D("3, 3"));

        private readonly List<MarkPoint2D> _markedSlashDiagonalData =
            new List<MarkPoint2D>().AddMarkPoint2Ds(
                new MarkPoint2D("0, 0"),
                new MarkPoint2D("1, 1"),
                new MarkPoint2D("2, 2"),
                new MarkPoint2D("3, 3"));

        private readonly List<MarkPoint2D> _markedBackSlashDiagonalData =
            new List<MarkPoint2D>().AddMarkPoint2Ds(
                new MarkPoint2D("3, 0"),
                new MarkPoint2D("2, 1"),
                new MarkPoint2D("1, 2"),
                new MarkPoint2D("0, 3"));

        #endregion
    }
}