using CreditCard.Core.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CreditCard.Core.CustomValidationAttributes
{
    public class CardExpiryAttribute : ValidationAttribute
    {


        /// <summary>
        ///  Method which validates Credit Card issue date and verifies whether card has been expired or not as well
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isCardExpired = false;

            // this regex will only allow issue date of format for example 02/10 or 01/20 but not 02/1990 or 02-19 or 02\19
            // 
            if (Regex.Match(value.ToString(), @"^(0[1-9]|1[0-2])\/?([0-9]{2}|[0-9]{2})$").Success)
            {
                // Since expiry date can be 3 or 4 years from card issued date , fetching card expiry age from appsettings
                
                var expiryAgeConfiguration = (IOptions<GeneralConfiguration>)validationContext.GetService(typeof(IOptions<GeneralConfiguration>));
                var cardExpiryInYears = expiryAgeConfiguration.Value.CreditCardExpiryAgeInYears;
                var issueDateInDateFormat = DateTime.ParseExact(value.ToString(), "MM/yy", CultureInfo.InvariantCulture);
                var expiryDate = issueDateInDateFormat.AddYears((Convert.ToInt32(cardExpiryInYears)));
                if (expiryDate < DateTime.Now)
                {
                    isCardExpired = true;
                }
            }
            else
            {
                ValidationResult result = new ValidationResult("Invalid Credit Card Issue Date Format");
                return result;
            }
             
            if (isCardExpired)
            {
                ValidationResult result = new ValidationResult("Card has been Expired");
                return result;
            }
            return ValidationResult.Success;
        }
    }

}
