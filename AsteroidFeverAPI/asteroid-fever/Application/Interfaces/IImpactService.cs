using asteroid_fever.Domain.Enums;
using asteroid_fever.Domain.ValueObjects;
using System.Threading.Tasks;

namespace asteroid_fever.Application.Interfaces
{
    public interface IImpactService
    {
        public Task<ImpactResult> DetermineImpactTier(ImpactFactors factors);

    }
}
