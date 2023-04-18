using asteroid_fever.Application.Interfaces;
using asteroid_fever.Domain.SeedData;
using asteroid_fever.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asteroid_fever.Application.Services
{
    public class ImpactService : IImpactService
    {
        private readonly IEnumerable<ImpactTier> _impactTiers;

        public ImpactService()
        {
            _impactTiers = ImpactTierData.GetImpactTiers();
        }

        public async Task<ImpactResult> DetermineImpactTier(ImpactFactors factors)
        {
            var kineticEnergy = await Task.Run(() => factors.CalculateKineticEnergy());
            var determinedImpact = _impactTiers.FirstOrDefault(tier => tier.MatchesCriteria(kineticEnergy));
            var result = new ImpactResult
            {
                TierLevel = determinedImpact?.TierLevel,
                KineticEnergy = kineticEnergy
            };
            return result;
        }
    }
}
