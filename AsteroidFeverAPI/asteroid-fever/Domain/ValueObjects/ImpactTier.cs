using asteroid_fever.Domain.Enums;
using System;

namespace asteroid_fever.Domain.ValueObjects
{
    public class ImpactTier
    {
        public ImpactTierLevel? TierLevel { get; set; }
        public double MinKineticEnergy { get; set; }
        public double MaxKineticEnergy { get; set; }
    }

    public static class ImpactTierExtensions
    {
        public static bool MatchesCriteria(this ImpactTier tier, double kineticEnergy)
        {
            return IsWithinRange(kineticEnergy, tier.MinKineticEnergy, tier.MaxKineticEnergy);
        }

        private static bool IsWithinRange(double value, double min, double max)
        {
            return value >= min && value <= max;
        }
    }
}
