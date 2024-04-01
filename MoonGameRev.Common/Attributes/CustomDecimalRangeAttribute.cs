using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonGameRev.Common.Attributes
{
    public class CustomDecimalRangeAttribute : ValidationAttribute
    {
        private readonly double _minimum;
        private readonly double _maximum;

        public CustomDecimalRangeAttribute(double minimum, double maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                double parsedValue;
                if (double.TryParse(value.ToString(), out parsedValue))
                {
                    if (parsedValue < _minimum || parsedValue > _maximum)
                    {
                        return new ValidationResult($"The field {validationContext.DisplayName} must be between {_minimum} and {_maximum}.");
                    }
                }
                else
                {
                    return new ValidationResult($"The field {validationContext.DisplayName} is not a valid number.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
