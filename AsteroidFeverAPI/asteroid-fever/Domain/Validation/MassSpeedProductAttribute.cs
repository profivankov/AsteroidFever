using asteroid_fever.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System;

namespace asteroid_fever.Domain.Validation
{
    public class MassSpeedProductAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var impactFactors = (ImpactFactors)validationContext.ObjectInstance;

            if (impactFactors.Mass > 0 && impactFactors.Speed > 0)
            {
                double product = impactFactors.Mass * impactFactors.Speed;
                if (product > Double.MaxValue)
                {
                    return new ValidationResult("The product of mass and speed must not exceed the maximum value.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
