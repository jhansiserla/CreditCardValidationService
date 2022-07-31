# CreditCardValidationService

This CreditCardValidationService API is to validate Credit Card Information such as Card Owner Name, Credit Card Number, Issue Date and CVC. Once after successful validation this API would return Credit Card Type based on input data.
* Tech Stack : C#, .NET CORE 3.1(Framework)
* Validations : 
  * CreditCardOwnerName : As it should not have other CreditCard Information like Card Number, Issue date and CVC which are all of digits, only alphabets are allowed.
  * CreditCardNumber : Only Visa,Master Card,American Express card numbers are allowed.
  * IssueDAte : Date should be in mm/yy format and expiry date is being calculated as IssueDate + 4 years. This 4 years value is configurable inside application.
  * CVC : CVC is being validated against the Card Number since CVC is different for respective card types.
* After validations, API would return if there are any validation errors . For proper input, API returns Card Type.

This API can be tested either manually or automatically.
* Manual Testing : Swagger has been integrated inside this application. And to test this is the URL : "http://localhost:15797/swagger/index.html".
* AutomationTesting : There is an automation project which would call this service via http protocol which is hosted locally and would return success response for                           valid input and validation errors for not valid input.
                      Below is the automation repo URL
