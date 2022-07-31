using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using CreditCard.Core.Enums;
using CreditCard.Core.Utilities;
using CreditCard.Core.CustomValidationAttributes;

namespace CreditCard.Core.Entities
{
    public class CreditCard  
    {
       [Required(ErrorMessage ="Credit Card Owner name is required")]
       [CardOwnerName]
        public string CreditCardOwnerName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Credit Card number is required")]
        [CardNumer]
        public string CreditCardNumber
        {
            get;
            set;
        }

        [Required(ErrorMessage ="Issue Date is required")]
        [CardExpiry]
        public string IssueDate
        {
            get;
            set;
        }

        [Required(ErrorMessage = "CVC is required")]
        [CVC]
        public Int64 CVC
        {
            get;
            set;
        }

    }
}
