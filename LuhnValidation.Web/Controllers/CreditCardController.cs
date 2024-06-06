using LuhnValidationDoodle.DataAccess.Services;
using LuhnValidationDoodle.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuhnValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

      
        // Validates the given credit card number using Luhn algorithm.
       [HttpPost("validate")]
        public ActionResult<CreditCardResponse> ValidateCreditCard([FromBody] CreditCardRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.CreditCardNumber))
                return BadRequest(new CreditCardResponse { IsValid = false });

            bool isValid = _creditCardService.IsValidCreditCard(request.CreditCardNumber);
            return Ok(new CreditCardResponse { IsValid = isValid });
        }
    }
}
