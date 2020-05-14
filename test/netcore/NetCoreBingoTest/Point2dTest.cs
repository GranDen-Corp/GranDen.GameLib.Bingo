using System;
using System.Collections.Generic;
using GranDen.GameLib.Bingo;
using Xunit;

namespace NetCoreBingoTest
{
    public class Point2dTest
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

        [Theory]
        [MemberData(nameof(Normal4X4_BingoPrizRReData.HorizontalPrize),
            MemberType = typeof(Normal4X4_BingoPrizRReData))]
        public void TestShouldGetHorizontalPrize(List<PrizeLine2D> prizeLines)
        {
            Assert.NotEmpty(prizeLines);

            //Arrange
            List<MarkPoint2D> test1StRowData = _marked1StRowData;
            List<MarkPoint2D> test2NdRowData = _marked2NdRowData;
            List<MarkPoint2D> test3RdRowData = _marked3RdRowData;
            List<MarkPoint2D> test4ThRowData = _marked4ThRowData;

            var bingo = new Bingo2dPrizeClincher(prizeLines);

            //Act
            var match1 = bingo.Decide(test1StRowData);
            var match2 = bingo.Decide(test2NdRowData);
            var match3 = bingo.Decide(test3RdRowData);
            var match4 = bingo.Decide(test4ThRowData);

            //Assert
            Assert.NotEmpty(match1);
            Assert.Single(match1);
            Assert.Equal("Horizontal Line1", match1[0]);

            Assert.NotEmpty(match2);
            Assert.Single(match2);
            Assert.Equal("Horizontal Line2", match2[0]);

            Assert.NotEmpty(match3);
            Assert.Single(match3);
            Assert.Equal("Horizontal Line3", match3[0]);

            Assert.NotEmpty(match4);
            Assert.Single(match4);
            Assert.Equal("Horizontal Line4", match4[0]);
        }

        [Theory]
        [MemberData(nameof(Normal4X4_BingoPrizRReData.VerticalPrize), MemberType = typeof(Normal4X4_BingoPrizRReData))]
        public void TestShouldGetVerticalPrize(List<PrizeLine2D> prizeLines)
        {
            Assert.NotEmpty(prizeLines);
            
            //Arrange
            var test1StColData = _marked1StColData;
            var test2NdColData = _marked2NdColData;
            var test3RdColData = _marked3rdColData;
            var test4ThColData = _marked4thColData;
            
            var bingo = new Bingo2dPrizeClincher(prizeLines);
            
            //Act
            var match1 = bingo.Decide(test1StColData);
            var match2 = bingo.Decide(test2NdColData);
            var match3 = bingo.Decide(test3RdColData);
            var match4 = bingo.Decide(test4ThColData);
            
            //Assert
            Assert.NotEmpty(match1);
            Assert.Single(match1);
            Assert.Equal("Vertical Line1", match1[0]);
            
            Assert.NotEmpty(match2);
            Assert.Single(match2);
            Assert.Equal("Vertical Line2", match2[0]);
            
            Assert.NotEmpty(match3);
            Assert.Single(match3);
            Assert.Equal("Vertical Line3", match3[0]);
            
            Assert.NotEmpty(match4);
            Assert.Single(match4);
            Assert.Equal("Vertical Line4", match4[0]);
        }

        [Theory]
        [MemberData(nameof(Normal4X4_BingoPrizRReData.DiagonalPrize), MemberType = typeof(Normal4X4_BingoPrizRReData))]
        public void TestShouldGetDiagonalPrize(List<PrizeLine2D> prizeLines)
        {
            Assert.NotEmpty(prizeLines);

            //Arrange
            var test1DiagonalData = _markedSlashDiagonalData;
            var test2DiagonalData = _markedBackSlashDiagonalData;

            var bingo = new Bingo2dPrizeClincher(prizeLines);

            //Act
            var match1 = bingo.Decide(test1DiagonalData);
            var match2 = bingo.Decide(test2DiagonalData);
            
            //Assert
            Assert.NotEmpty(match1);
            Assert.Single(match1);
            Assert.Equal("Diagonal Line1", match1[0]);

            Assert.NotEmpty(match2);
            Assert.Single(match2);
            Assert.Equal("Diagonal Line2", match2[0]);
        }

        readonly List<MarkPoint2D> _marked1StRowData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 0, true),
            new MarkPoint2D(1, 0, true),
            new MarkPoint2D(2, 0, true),
            new MarkPoint2D(3, 0, true)
        };

        readonly List<MarkPoint2D> _marked2NdRowData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 1, true),
            new MarkPoint2D(1, 1, true),
            new MarkPoint2D(2, 1, true),
            new MarkPoint2D(3, 1, true)
        };

        readonly List<MarkPoint2D> _marked3RdRowData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 2, true),
            new MarkPoint2D(1, 2, true),
            new MarkPoint2D(2, 2, true),
            new MarkPoint2D(3, 2, true)
        };

        readonly List<MarkPoint2D> _marked4ThRowData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 3, true),
            new MarkPoint2D(1, 3, true),
            new MarkPoint2D(2, 3, true),
            new MarkPoint2D(3, 3, true)
        };

        readonly List<MarkPoint2D> _marked1StColData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 0, true),
            new MarkPoint2D(0, 1, true),
            new MarkPoint2D(0, 2, true),
            new MarkPoint2D(0, 3, true)
        };

        readonly List<MarkPoint2D> _marked2NdColData = new List<MarkPoint2D>
        {
            new MarkPoint2D(1, 0, true),
            new MarkPoint2D(1, 1, true),
            new MarkPoint2D(1, 2, true),
            new MarkPoint2D(1, 3, true)
        };

        readonly List<MarkPoint2D> _marked3rdColData = new List<MarkPoint2D>
        {
            new MarkPoint2D(2, 0, true),
            new MarkPoint2D(2, 1, true),
            new MarkPoint2D(2, 2, true),
            new MarkPoint2D(2, 3, true)
        };
        
        readonly List<MarkPoint2D> _marked4thColData = new List<MarkPoint2D>
        {
            new MarkPoint2D(3, 0, true),
            new MarkPoint2D(3, 1, true),
            new MarkPoint2D(3, 2, true),
            new MarkPoint2D(3, 3, true)
        };

        readonly List<MarkPoint2D> _markedSlashDiagonalData = new List<MarkPoint2D>
        {
            new MarkPoint2D(0, 0, true),
            new MarkPoint2D(1, 1, true),
            new MarkPoint2D(2, 2, true),
            new MarkPoint2D(3, 3, true)
        };

        readonly List<MarkPoint2D> _markedBackSlashDiagonalData = new List<MarkPoint2D>
        {
            new MarkPoint2D(3, 0, true),
            new MarkPoint2D(2, 1, true),
            new MarkPoint2D(1, 2, true),
            new MarkPoint2D(0, 3, true)
        };

    }
}