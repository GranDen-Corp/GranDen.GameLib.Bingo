﻿using GranDen.GameLib.Bingo.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GranDen.GameLib.Bingo
{
    /// <summary>
    /// Utility methods for easier construct PrizeLine2D objects collection
    /// </summary>
    public static class PrizeLine2dExtenstion
    {
        private static readonly Regex _Regex = new Regex(
        "^\\s*(?:(?<tuple>\\(\\s*\\d+\\s*,\\s*\\d+\\s*\\))\\s*,?\\s*)+(?:\\|\\s*){1}(?:\\'|\\\"){1}(?<name>(.+))(?:\\'|\\\")$",
        RegexOptions.CultureInvariant | RegexOptions.Compiled
        );
        
        /// <summary>
        /// Create <c>PrizeLine2D</c> object from "(0, 0), (1, 1), (2, 2) | 'Diagonal Line' string
        /// </summary>
        /// <param name="rawString"></param>
        /// <returns></returns>
        public static PrizeLine2D ToPrizeLine2d(this string rawString)
        {
            var matches = _Regex.Matches(rawString).Cast<Match>().ToList();

            if (!matches.Any())
            {
                throw new FormatException();
            }
            var match = matches.First();
            var nameStr = match.Groups["name"].Value;

            var tuples = match.Groups["tuple"].Captures.Cast<Capture>().Select(c => new IntPoint2D(c.Value));

            return new PrizeLine2D(tuples, nameStr);
        }
    }
}
