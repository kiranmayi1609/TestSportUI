using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestAPI.Service;

namespace SportTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly StripeService _stripeService;
        public StripeController(StripeService stripeService)
        {
            _stripeService = stripeService;
        }
        [HttpPost("create-payment-intent")]
        public IActionResult CreatePaymentIntent([FromBody] decimal amount, [FromQuery] string currency="Dkk")
        {
            var clientSecret = _stripeService.CreatePaymentIntent(amount, currency);
            return Ok(new { clientSecret });

        }
    }
}
