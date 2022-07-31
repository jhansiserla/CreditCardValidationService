using CreditCard.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace CreditCard.Core.CustomValidationAttributes
{
    public class CardOwnerNameAttribute : ValidationAttribute
    {
       /// <summary>
       /// Method which validates credit card owner name
       /// </summary>
       /// <param name="value"></param>
       /// <param name="validationContext"></param>
       /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isValidCardOwnerName = false;
            if (new Regex(@"^[a-zA-Z]+$").IsMatch(value.ToString()))
            {
                isValidCardOwnerName = true;
            }
            if (!isValidCardOwnerName)
            {
                ValidationResult result = new ValidationResult("Invalid Credit Card Owner Name");
                return result;
            }
            return ValidationResult.Success;
        }
    }
}
