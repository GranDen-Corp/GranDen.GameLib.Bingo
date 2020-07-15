using System.Collections.Generic;
using System.Linq;

namespace GranDen.GameLib.Bingo
{
    /// <summary>
    /// Utility extension method for easier initiate MarkPoint2D data collection
    /// </summary>
    public static class MarkPoint2dCollectionExtension
    {
        /// <summary>
        /// Add many <see cref="MarkPoint2D"/> objects to a List&lt;<see cref="MarkPoint2D"/>&gt; collection
        /// </summary>
        /// <param name="pointList"></param>
        /// <param name="markPoint2Ds"></param>
        /// <returns></returns>
        public static List<MarkPoint2D> AddMarkPoint2Ds(this List<MarkPoint2D> pointList, params MarkPoint2D[] markPoint2Ds)
        {
            pointList.AddRange(markPoint2Ds);
            return pointList;
        }

        /// <summary>
        /// Add many (x, y, true|false) tuples to a LList&lt;<see cref="MarkPoint2D"/>&gt; collectionn
        /// </summary>
        /// <param name="pointList"></param>
        /// <param name="tuples"></param>
        /// <returns></returns>
        public static List<MarkPoint2D> AddMarkPoint2Ds(this List<MarkPoint2D> pointList,
            params (int x, int y, bool marked)[] tuples)
        {
            pointList.AddMarkPoint2Ds(tuples.Select(t => new MarkPoint2D(t)).ToArray());
            return pointList;
        }

        /// <summary>
        /// Add many (x, y, true|false) tuples to a <see cref="MarkPoint2D"/> array
        /// </summary>
        /// <param name="markPoint2Ds"></param>
        /// <param name="tuples"></param>
        /// <returns></returns>
        public static MarkPoint2D[] AddMarkPoint2Ds(this IEnumerable<MarkPoint2D> markPoint2Ds,
            params (int x, int y, bool makred)[] tuples)
        {
            return markPoint2Ds.ToList().AddMarkPoint2Ds(tuples).ToArray();
        }
    }
}
