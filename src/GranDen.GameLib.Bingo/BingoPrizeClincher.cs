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
        private readonly List<PrizeLine2D<T>> _prizeLines;

        /// <summary>
        /// Create a 2D line bingo game line detection engine
        /// </summary>
        /// <param name="prizeLines"></param>
        public Bingo2dPrizeClincher(List<PrizeLine2D<T>> prizeLines)
        {
            _prizeLines = prizeLines;
        }

        /// <summary>
        /// Decide currently achieved bingo line(s).
        /// </summary>
        /// <param name="inputs">The mark points in (x, y, true|false) tuple format</param>
        /// <returns></returns>
        public List<T> Decide(List<MarkPoint2D> inputs)
        {
            var matchedPrizes = new List<T>();

            if (inputs == null || !inputs.Any())
            {
                return matchedPrizes;
            }

            //Note: should use nested tuple dictionary lookup via organize inputs array for multi-core/threads processing, Or just using Linq to check prizeLines' Points value matches in input?
            foreach (var prizeLine in _prizeLines)
            {
                if (prizeLine.Points.All(prizePoint => inputs.Any( i => i.Marked && i.X == prizePoint.X && i.Y == prizePoint.Y)))
                {
                    matchedPrizes.Add(prizeLine.Prize);
                }
            }

            return matchedPrizes;
        }
    }
}