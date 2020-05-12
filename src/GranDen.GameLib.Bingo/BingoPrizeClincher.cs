using System.Collections.Generic;
using System.Linq;

namespace GranDen.GameLib.Bingo
{
    public class Bingo2dPrizeClincher
    {
        private readonly List<PrizeLine2D> _prizeLines;

        public Bingo2dPrizeClincher(List<PrizeLine2D> prizeLines)
        {
            _prizeLines = prizeLines;
        }

        public List<string> Decide(List<MarkPoint2D> inputs)
        {
            var matchedPrizes = new List<string>();

            if (inputs == null || !inputs.Any())
            {
                return matchedPrizes;
            }

            //Note: should use nested tuple dictionary lookup via organize inputs array for multi-core/threads processing, Or just using Linq to check prizeLines' Points value matches in input?
            foreach (var prizeLine in _prizeLines)
            {
                if (prizeLine.Points.All(prizePoint => inputs.Any( i => i.Marked && i.X == prizePoint.X && i.Y == prizePoint.Y)))
                {
                    matchedPrizes.Add(prizeLine.Name);
                }
            }

            return matchedPrizes;
        }
    }
}