using System;
using System.Collections.Generic;
using System.Text;

namespace Kezyma.EloRating
{
    public static class EloCalculator
    {
        private const int KFACTOR = 15;

        public const double WIN = 1;
        public const double LOSE = 0;
        public const double DRAW = 0.5;

        /// <summary>
        /// Calculates ELO
        /// </summary>
        /// <param name="currentRatingA">Current A Rank</param>
        /// <param name="currentRatingB">Current B Rank</param>
        /// <param name="scoreA">A Score (1 = Win, 0.5 = Draw, 0 = Loss)</param>
        /// <param name="scoreB">B Score (1 = Win, 0.5 = Draw, 0 = Loss)</param>
        /// <param name="kFactorA">K Factor A (15 by default)</param>
        /// <param name="kFactorB">K Factor B (15 by default)</param>
        /// <returns></returns>
        public static decimal[] CalculateElo(decimal currentRatingA, decimal currentRatingB, decimal scoreA, decimal scoreB, int kFactorA = KFACTOR, int kFactorB = KFACTOR)
        {
            var exp = PredictResult(currentRatingA, currentRatingB);
            var na = currentRatingA + (kFactorA * (scoreA - exp[0]));
            var nb = currentRatingB + (kFactorB * (scoreB - exp[1]));
            return new decimal[] { na, nb };
        }

        public static decimal[] PredictResult(decimal currentRatingA, decimal currentRatingB)
        {
            var ea = 1 / (1 + (decimal)Math.Pow(10, (double)(currentRatingB - currentRatingA) / 400));
            var eb = 1 / (1 + (decimal)Math.Pow(10, (double)(currentRatingA - currentRatingB) / 400));
            return new decimal[] { ea, eb };
        }
    }
}
