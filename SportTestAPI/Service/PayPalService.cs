using PayPal.Api;

namespace SportTestAPI.Service
{
    public class PayPalService
    {
        private readonly APIContext _apiContext;

        public PayPalService(IConfiguration config)
        {
            var clientId = config["PayPal:ClientId"];
            var clientSecret = config["PayPal:ClientSecret"];
            var mode = config["PayPal:Mode"];

            var configDictionary = new Dictionary<string, string>
            {
                {"mode",mode }
            };

            var accessToken = new OAuthTokenCredential(clientId, clientSecret, configDictionary).GetAccessToken();
            _apiContext = new APIContext(accessToken) { Config = configDictionary };
            
        }
        public Payment CreatePayment(decimal amount,string returnUrl,string cancelUrl)
        {
            var payment = new Payment
            {
                intent = 'sale',
                payer = new Payer { payment_method = "paypal" },
                transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        amount =new Amount
                        {
                            currency="USD",
                            total=amount.ToString("F2")
                        },
                        description= "Payment description"

                    }
                },
                redirect_urls= new RedirectUrls
                {
                    return_url=returnUrl,
                    cancel_url=cancelUrl
                }
            };
            return payment.Create(_apiContext);

        }

        public Payment ExecutePayment(string paymentId,string payerId)
        {
            var paymentExecution = new PaymentExecution { payer_id = payerId };
            var payment = new Payment { id = paymentId };

            return payment.Execute(_apiContext, paymentExecution);

        }
    }
}
