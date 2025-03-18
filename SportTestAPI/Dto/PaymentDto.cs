namespace SportTestAPI.Dto
{
    public class PaymentDto
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; } = "Dkk";

        public string Description { get;set; }
        public string ReturnUrl { get;set; }

        public string CancelUrl { get;set; }
    }
}
