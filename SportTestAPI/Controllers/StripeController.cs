using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestAPI.Service;
using Stripe;

namespace SportTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly StripeService _stripeService;
        private readonly ILogger<StripeController> _logger;


        public StripeController(StripeService stripeService, ILogger<StripeController> logger)
        {
            _stripeService = stripeService;
            _logger = logger;
        }
        [HttpPost("create-payment-intent")]
        public IActionResult CreatePaymentIntent([FromBody] decimal amount, [FromQuery] string currency = "usd")
        {
            //var clientSecret = _stripeService.CreatePaymentIntent(amount, currency);
            //return Ok(new { clientSecret });
            try
            {
                var clientSecret = _stripeService.CreatePaymentIntent(amount, currency);
                return Ok(new { clientSecret });
            }
            catch (StripeException ex)
            {
                _logger.LogError($"Stripe Error: {ex.StripeError.Message}");
                return StatusCode(500, new { error = ex.StripeError.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected Error: {ex.Message}");
                return StatusCode(500, new { error = "An unexpected error occurred." });
            }
        }

    
    }
}
