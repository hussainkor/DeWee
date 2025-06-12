using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeWee.Models
{
    public class RequiredIfTrueAttribute : ValidationAttribute
    {
        private readonly string _dependentProperty;

        public RequiredIfTrueAttribute(string dependentProperty)
        {
            _dependentProperty = dependentProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_dependentProperty);

            if (propertyInfo == null)
                return new ValidationResult($"Unknown property: {_dependentProperty}");

            var dependentValue = propertyInfo.GetValue(validationContext.ObjectInstance) as bool?;

            if (dependentValue == true)
            {
                if (value == null || (value is string strValue && string.IsNullOrWhiteSpace(strValue)))
                {
                    return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} is required when {_dependentProperty} is true.");
                }
            }

            return ValidationResult.Success;
        }
    }
}