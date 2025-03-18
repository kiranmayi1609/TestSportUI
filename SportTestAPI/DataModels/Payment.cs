using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SportTestAPI.DataModels
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string currency { get; set; } = "Dkk";

        [Required]
        public string Description { get;set; }
        [Required]
        public string PaymentId { get; set; }

        [Required]

        public string PayerId { get; set; }

        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
