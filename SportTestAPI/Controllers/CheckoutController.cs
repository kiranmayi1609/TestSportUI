//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SportTestAPI.Service;

//namespace SportTestAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CheckoutController : ControllerBase
//    {
//        private readonly PayPalService _payPalService;

//        public CheckoutController(PayPalService payPalService)
//        {
//            _payPalService = payPalService;
            
//        }
//        [HttpPost("create-payment")]
//        public IActionResult CreatePayment([FromBody] decimal amount )
//        {
//            var returnUrl = "";
//            var cancelUrl = "";

//            var payment = _payPalService.CreatePayment(amount, returnUrl, cancelUrl);
//            return Ok(payment.GetApprovalUrl());
//        }

//        [HttpPost("execute-payment")]
//        public IActionResult ExecutePayment([FromQuery] string paymentId, [FromQuery] string payerId)
//        {
//            var payment = _payPalService.ExecutePayment(paymentId, payerId);
//            return Ok(payment);
//        }

//        //"authentication": "https://api-m.sandbox.paypal.com/v1/oauth2/token"
//    }
//}
