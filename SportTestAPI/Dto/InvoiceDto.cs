using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.Dto
{
    public class InvoiceRequestDto
    {
        [Required]
        public string UserID { get; set; }  // The UserID of the user to whom the invoice is assigned.

        [Required]
        public decimal Amount { get; set; }  // The amount for the invoice.

        [Required]
        public string Status { get; set; }  // The status of the invoice (e.g., Paid, Pending, Canceled).

        [Required]
        public string PaymentMethod { get; set; }  // Payment method used for the invoice (e.g., Credit Card, PayPal).

        public DateTime DateIssued { get; set; }  // The date when the invoice was issued.
    }

    public class InvoiceResponseDto
    {
        public int InvoiceID { get; set; }  // Unique identifier for the invoice.

        public string UserID { get; set; }  // The UserID associated with the invoice.

        public string UserName { get; set; }  // The name of the user associated with the invoice.

        public decimal Amount { get; set; }  // The amount of the invoice.

        public string Status { get; set; }  // The status of the invoice (Paid, Pending, etc.).

        public string PaymentMethod { get; set; }  // Payment method used (Credit Card, PayPal, etc.).

        public DateTime DateIssued { get; set; }  // The date when the invoice was issued.
    }


}
