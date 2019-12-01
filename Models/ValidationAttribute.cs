using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime check = (DateTime)value;
            if ((DateTime.Now - check).Days >= 0) {
                return new ValidationResult("Date must be in the future!");
            }
            return ValidationResult.Success;
        }
    }
}