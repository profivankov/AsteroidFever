namespace AsteroidFever.Tests
{
    using asteroid_fever.Application.Services;
    using asteroid_fever.Domain.Enums;
    using asteroid_fever.Domain.ValueObjects;
    using Xunit;
    using asteroid_fever.Application.Interfaces;

    public class ImpactServiceTests
    {
        private readonly IImpactService _impactService;
        public ImpactServiceTests() {
            _impactService = new ImpactService();
        }

        [Fact]
        public async void DetermineImpactTier_ReturnsNull_WhenNoMatchingTier()
        {
            // Arrange
            var factors = new ImpactFactors()
            {
                Mass = -1,
                Speed = -1
            };

            // Act
            var result = await _impactService.DetermineImpactTier(factors);

            // Assert
            Assert.Null(result.TierLevel);
        }

        [Theory]
        [InlineData(10000, 1000, ImpactTierLevel.LocalizedDamage)]
        [InlineData(100000, 10000, ImpactTierLevel.ContinentalImpact)]
        [InlineData(1000000000, 1000000000, ImpactTierLevel.EarthDestruction)]
        public async void DetermineRealisticImpactTier_ReturnsCorrectTier(double mass, double speed, ImpactTierLevel tier)
        {
            // Arrange
            var factors = new ImpactFactors
            {
                Mass = mass,
                Speed = speed
            };

            // Act
            var result = await _impactService.DetermineImpactTier(factors);

            // Assert
            Assert.Equal(tier, result.TierLevel);
        }
    }
}