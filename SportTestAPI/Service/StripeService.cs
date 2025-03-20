using Stripe;

namespace SportTestAPI.Service
{
    public class StripeService
    {
        private readonly string _secretKey;
        private readonly ILogger<StripeService> _logger;


        public StripeService(IConfiguration config, ILogger<StripeService> logger)
        {
            _secretKey = config["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _secretKey;
            _logger = logger;

        }

        public string CreatePaymentIntent(decimal amount,string currency)
        {
            try
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(amount * 100), // Convert to cents
                    Currency = currency.ToLower(), // Ensure lowercase currency code
                    PaymentMethodTypes = new List<string> { "card" }
                };

                var service = new PaymentIntentService();
                var intent = service.Create(options);
                return intent.ClientSecret;
            }
            catch (StripeException ex)
            {
                _logger.LogError($"Stripe Error: {ex.Message}");
                throw; // Re-throw the exception to handle it in the controller
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected Error: {ex.Message}");
                throw; // Re-throw the exception to handle it in the controller
            }
        }


        //var oprions = new PaymentIntentCreateOptions
        //{
        //    Amount = (long)(amount * 100),
        //    Currency = currency,
        //    PaymentMethodTypes = new List<string> { "card" }
        //};

        //var service = new PaymentIntentService();
        //var intent = service.Create(oprions);
        //return intent.ClientSecret;
    
    }
}
