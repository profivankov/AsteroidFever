using asteroid_fever.Domain.Enums;

namespace asteroid_fever.Domain.ValueObjects
{
    public class ImpactResult
    {
        public ImpactTierLevel? TierLevel { get; set; }
        public double KineticEnergy { get; set; }
    }
}
