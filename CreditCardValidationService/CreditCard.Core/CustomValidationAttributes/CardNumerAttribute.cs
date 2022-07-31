using CreditCard.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using CreditCard.Core.Utilities;

namespace CreditCard.Core.CustomValidationAttributes
{
    public class CardNumerAttribute : ValidationAttribute
    {

        /// <summary>
        ///  Method which validates Credit card number and allows only Visa/Master card/American Express card types
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isValidCardNumber = CreditCardNumberHelper.isValidCardNumber(value.ToString());
           
            if (!isValidCardNumber)
            {
                ValidationResult result = new ValidationResult("Invalid Credit Card Number");
                return result;
            }
            return ValidationResult.Success;
        }
    }
}
