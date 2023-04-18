using asteroid_fever.Domain.Enums;
using asteroid_fever.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace asteroid_fever.Domain.SeedData
{
    public static class ImpactTierData
    {
        public static IList<ImpactTier> GetImpactTiers()
        {
            return new List<ImpactTier>
        {
                new ImpactTier
                {
                    TierLevel = ImpactTierLevel.None,
                    MinKineticEnergy = 0,
                    MaxKineticEnergy = Math.Pow(10, 6)
                },
                new ImpactTier
                {
                    TierLevel = ImpactTierLevel.MinimalImpact,
                    MinKineticEnergy = Math.Pow(10, 6),
                    MaxKineticEnergy = Math.Pow(10, 9)
                },
                new ImpactTier
                {
                    TierLevel = ImpactTierLevel.LocalizedDamage,
                    MinKineticEnergy = Math.Pow(10, 9),
                    MaxKineticEnergy = Math.Pow(10, 12)
                },
                new ImpactTier
                {
                    TierLevel = ImpactTierLevel.ContinentalImpact,
                    MinKineticEnergy = Math.Pow(10, 12),
                    MaxKineticEnergy = Math.Pow(10, 15)
                },
                new ImpactTier
                {
                    TierLevel = ImpactTierLevel.GlobalCatastrophe,
                    MinKineticEnergy = Math.Pow(10, 15),
                    MaxKineticEnergy = Math.Pow(10, 20)
                },
                new ImpactTier
                {
                    TierLevel = ImpactTierLevel.EarthDestruction,
                    MinKineticEnergy = Math.Pow(10, 20),
                    MaxKineticEnergy = Double.MaxValue
                }
            };
        }
    }
}
