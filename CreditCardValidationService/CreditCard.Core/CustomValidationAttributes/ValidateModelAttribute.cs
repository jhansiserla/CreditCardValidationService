using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace CreditCard.Core.CustomValidationAttributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Method which checks for valid model and if not returns Bad request
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
