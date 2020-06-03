using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models.CustomValidators
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if( value != null)
            {
                string[] inputString = value.ToString().Split('@');
                if (inputString.Length > 1 && inputString[1].ToUpper() == AllowedDomain.ToUpper())
                {
                    return null;
                }

                return new ValidationResult($"Domain must be {AllowedDomain}",
                new[] { validationContext.MemberName });
            }
            return null;

        }
    }
}
