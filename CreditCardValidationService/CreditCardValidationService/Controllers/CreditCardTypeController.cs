using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CreditCard.Core.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditCardValidationService
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardTypeController : ControllerBase
    {
        // GET: api/<CreditCardInfoController>

        [HttpPost]
        [CreditCard.Core.CustomValidationAttributes.ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string GetCardType(CreditCard.Core.Entities.CreditCard creditCard)
        {
            return CreditCardNumberHelper.GetCreditCardType(creditCard.CreditCardNumber);
        }
      
    }
}
