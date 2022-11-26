using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Common.Models
{
    public class BorrowerNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var name = value.ToString();

            if (String.IsNullOrEmpty(name))
            {
                return new ValidationResult("The name cannot be null or empty",
                new[] { validationContext.MemberName });
            }

            if (String.IsNullOrWhiteSpace(name))
            {
                return new ValidationResult("The name cannot be null or whitespace",
                new[] { validationContext.MemberName });
            }

            foreach (var c in name)
            {
                if (!Char.IsLetterOrDigit(c) && c != ' ')
                {
                    return new ValidationResult("The name cannot special character",
                        new[] { validationContext.MemberName });
                }
            }

            return null;
        }
    }
}
