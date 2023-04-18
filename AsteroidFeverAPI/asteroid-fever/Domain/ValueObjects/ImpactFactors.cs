using asteroid_fever.Domain.Enums;
using asteroid_fever.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace asteroid_fever.Domain.ValueObjects
{
    [MassSpeedProduct(ErrorMessage = "The product of mass and speed is too high.")]
    public class ImpactFactors
    {
        [Range(0, Double.MaxValue)]
        public double Mass { get; set; }
        [Range(0, Double.MaxValue)]
        public double Speed { get; set; }
        [Range(0, 6)]
        public double? Angle { get; set; }
        [Range(0, Double.MaxValue)]
        public double? Size { get; set; }
        public Material? Material { get; set; }
        public double? Density { get; set; }
        public double? AtmosphericDensity { get; set; }

        public bool AreOptionalPropertiesNull()
        {
            return Angle == null && Size == null && Material == null && Density == null && AtmosphericDensity == null;
        }
    }

    public static class ImpactFactorsExtensions
    {
        public static double CalculateKineticEnergy(this ImpactFactors factors)
        {
            double kineticEnergy = 0.5 * factors.Mass * Math.Pow(factors.Speed, 2);

            if (factors.AreOptionalPropertiesNull())
            {
                return kineticEnergy;
            }
            else
            {
                return CalculateAdjustedKineticEnergy(factors, kineticEnergy);
            }
        }

        private static double CalculateAdjustedKineticEnergy(this ImpactFactors factors, double kineticEnergy)
        {
            double angleAdjustment = factors.Angle.HasValue ? CalculateAngleAdjustment(factors.Angle.Value) : 1.0;
            double sizeAdjustment = factors.Size.HasValue ? CalculateSizeAdjustment(factors.Size.Value) : 1.0;
            double materialAdjustment = factors.Material.HasValue ? factors.Material.Value.Strength() : 1.0;
            double densityAdjustment = factors.Density.HasValue ? CalculateDensityAdjustment(factors.Density.Value) : 1.0;
            double atmosphericAdjustment = factors.AtmosphericDensity.HasValue ? CalculateAtmosphericAdjustment(factors.AtmosphericDensity.Value) : 1.0;

            try
            {
                double adjustedKineticEnergy = checked(kineticEnergy * angleAdjustment * sizeAdjustment * materialAdjustment * densityAdjustment * atmosphericAdjustment);

                if (adjustedKineticEnergy < 0)
                {
                    return Double.MaxValue;
                }
                return adjustedKineticEnergy;
            }
            catch (OverflowException)
            {
                return Double.MaxValue;
            }
        }

        private static double CalculateAngleAdjustment(double angle)
        {
            return Math.Cos(angle);
        }

        private static double CalculateSizeAdjustment(double size)
        {
            return Math.Pow(size, 0.5);
        }

        private static double CalculateDensityAdjustment(double density)
        {
            return density / 1000.0;
        }

        private static double CalculateAtmosphericAdjustment(double atmosphericDensity)
        {
            return 1.0 - (atmosphericDensity / 100.0);
        }

    }
}
