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
        [MemberData(nameof(Normal4X4_BingoPrizRReData.HorizontalPrize), MemberType = typeof(Normal4X4_BingoPrizRReData))]
        public void TestShouldGetHorizontalPrize(List<PrizeLine2D> prizeLines)
        {
            Assert.NotEmpty(prizeLines);

            //Arrange
            var bingo = new Bingo2dPrizeClincher(prizeLines);

            var test1StRowData = new List<MarkPoint2D>
            {
                new MarkPoint2D(0, 0, true), 
                new MarkPoint2D(1, 0, true), 
                new MarkPoint2D(2, 0, true), 
                new MarkPoint2D(3, 0, true)
            };

            var test2NdRowData = new List<MarkPoint2D>
            {
                new MarkPoint2D(0, 1, true),
                new MarkPoint2D(1, 1, true),
                new MarkPoint2D(2, 1, true),
                new MarkPoint2D(3, 1, true)
            };
            
            var test3RdRowData = new List<MarkPoint2D>
            {
                new MarkPoint2D(0, 2, true),
                new MarkPoint2D(1, 2, true),
                new MarkPoint2D(2, 2, true),
                new MarkPoint2D(3, 2, true)
            };

            var test4ThRowData = new List<MarkPoint2D>
            {
                new MarkPoint2D(0, 3, true),
                new MarkPoint2D(1, 3, true),
                new MarkPoint2D(2, 3, true),
                new MarkPoint2D(3, 3, true)
            };

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
    }
}
