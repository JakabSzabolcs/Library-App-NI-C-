using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Common.Models
{
    public class ReturnDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = Convert.ToDateTime(value);

            if (DateTime.Compare(date, DateTime.Now) < 0)
            {
                return new ValidationResult("The return date cannot be less then the borrowing date",
                new[] { validationContext.MemberName });
            }

            return null;
        }
    }
}
