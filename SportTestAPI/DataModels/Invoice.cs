using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.DataModels
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Required]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Status { get; set; }  // Paid, Pending, Canceled

        [Required]
        public string PaymentMethod { get; set; }  // Credit Card, PayPal, etc.

        public DateTime DateIssued { get; set; }
    }
}
