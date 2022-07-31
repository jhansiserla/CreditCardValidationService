using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CreditCard.Core.Enums;


namespace CreditCard.Core.Utilities
{
    public static class CreditCardNumberHelper
    {
        private static Dictionary<CreditCardType, string> _creditCardTypeRegexMap;

         static CreditCardNumberHelper()
        {
            _creditCardTypeRegexMap = new Dictionary<CreditCardType, string>
            {
                { CreditCardType.Visa, @"^4[0-9]{12}(?:[0-9]{3})?$"},
                { CreditCardType.MasterCard, @"(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$"},
                { CreditCardType.AmericanExpress, @"^3[47][0-9]{13}$" }
            };
        }


        /// <summary>
        /// Method which checks whether Card Number is valid or not
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public static bool isValidCardNumber(string cardNumber)
        {
            bool isValid = false;
            foreach (CreditCardType cardType in Enum.GetValues(typeof(CreditCardType)))
            {
                if (new Regex(_creditCardTypeRegexMap[cardType]).IsMatch(cardNumber))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }

        /// <summary>
        /// Methhod which fetches Card Type from given card number
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public static string GetCreditCardType(string cardNumber)
        {
            string creditCardType = string.Empty;
            foreach (CreditCardType cardType in Enum.GetValues(typeof(CreditCardType)))
            {
                if (new Regex(_creditCardTypeRegexMap[cardType]).IsMatch(cardNumber))
               {
                    creditCardType = cardType.ToString();
                    break;
               }
            }
            return creditCardType;
        }

        /// <summary>
        /// Method which checks for valid CVC from given input
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="cvc"></param>
        /// <returns></returns>
        public static bool IsValidCVC(string cardNumber, string cvc)
        {
            bool isValidCVC = false;
            var threeDigitsRegex = @"^[0-9]{3}$";
            var fourDigitsRegex = @"^[0-9]{4}$";
            var creditCardType = GetCreditCardType(cardNumber);
            if (creditCardType == CreditCardType.Visa.ToString() || creditCardType == CreditCardType.MasterCard.ToString())
            {
                if (new Regex(threeDigitsRegex).IsMatch(cvc))
                {
                    isValidCVC = true;
                }
            }

            else if (creditCardType.ToString() == CreditCardType.AmericanExpress.ToString())
            {
                if (new Regex(fourDigitsRegex).IsMatch(cvc))
                {
                    isValidCVC = true;
                }
            }
            return isValidCVC;
        }
    }
}
