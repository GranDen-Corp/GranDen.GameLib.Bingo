using System.Collections.Generic;
using System.Linq;

namespace GranDen.GameLib.Bingo
{
    /// <inheritdoc/>
    public class Bingo2dPrizeClincher : Bingo2dPrizeClincher<string>
    {
        /// <inheritdoc/>
        public Bingo2dPrizeClincher(List<PrizeLine2D> prizeLines) : base(prizeLines.Cast<PrizeLine2D<string>>().ToList())
        {
        }
    }

    /// <summary>
    /// 2D Bingo game achieved line detection engine
    /// </summary>
    public class Bingo2dPrizeClincher<T>
    {
        private readonly IList<PrizeLine2D<T>> _prizeLines;

        /// <summary>
        /// Create a 2D line bingo game line detection engine
        /// </summary>
        /// <param name="prizeLines"></param>
        public Bingo2dPrizeClincher(IEnumerable<PrizeLine2D<T>> prizeLines)
        {
            _prizeLines = prizeLines.ToList();
        }

        /// <summary>
        /// Decide currently achieved bingo line(s)
        /// </summary>
        /// <param name="inputs">The mark points in (x, y, true|false) tuple format</param>
        /// <returns></returns>
        public IEnumerable<T> Decide(IEnumerable<MarkPoint2D> inputs)
        {
            var matchedPrizes = new List<T>();

            var markPoint2Ds = inputs as MarkPoint2D[] ?? inputs.ToArray();
            if (!markPoint2Ds.Any())
            {
                return matchedPrizes;
            }

            matchedPrizes.AddRange(from prizeLine in _prizeLines
                where prizeLine.Points.All(
                    prizePoint =>
                    {
                        return markPoint2Ds.Any(i => i.Marked && i.X == prizePoint.X && i.Y == prizePoint.Y);
                    })
                select prizeLine.Prize);

            return matchedPrizes;
        }

        /// <summary>
        /// Decide currently achieved bingo line(s)
        /// </summary>
        /// <param name="inputs">The mark points in (x, y, true|false) tuple format</param>
        /// <returns></returns>
        public IList<T> Decide(List<MarkPoint2D> inputs)
        {
            return Decide(inputs as IEnumerable<MarkPoint2D>).ToList();
        }
    }
}
