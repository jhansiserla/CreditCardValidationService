using CreditCard.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using CreditCard.Core.Utilities;
namespace CreditCard.Core.CustomValidationAttributes
{
    public class CVCAttribute : ValidationAttribute
    {
        /// <summary>
        /// Method which validates CVC for specific card type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cardNumber = validationContext.ObjectType.GetProperty("CreditCardNumber").GetValue(validationContext.ObjectInstance);
            var isValidCVC = CreditCardNumberHelper.IsValidCVC(cardNumber.ToString(), value.ToString());
            if(!isValidCVC)
            {
                ValidationResult result = new ValidationResult("Invalid CVC");
                return result;
            }
            return ValidationResult.Success;
        }
    }
    }

