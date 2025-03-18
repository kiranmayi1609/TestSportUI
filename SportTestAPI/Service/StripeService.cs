using Stripe;

namespace SportTestAPI.Service
{
    public class StripeService
    {
        private readonly string _secretKey;

        public StripeService(IConfiguration config)
        {
            _secretKey = config["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _secretKey;
            
        }

        public string CreatePaymentIntent(decimal amount,string currency)
        {
            var oprions = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100),
                Currency = currency,
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            var intent = service.Create(oprions);
            return intent.ClientSecret;
        }
    }
}
