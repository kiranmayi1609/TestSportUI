using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Crypto.Macs;

namespace SportTestAPI.DataModels
{
   
     public class TrainingSession
    {
        [Key]
        public int SessionID { get; set; }

        [Required]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }

        [Required]
        public int CoachID { get; set; }
        [ForeignKey("CoachID")]
        public Coach Coach { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Duration { get; set; }  // in minutes

        public string Location { get; set; }

        [Required]
        public decimal Fee { get; set; }

        [Required]
        public int InvoiceID { get; set; }
        [ForeignKey("InvoiceID")]
        public Invoice Invoice { get; set; }  // Link to Payment

        [Required]
        public int AgeGroupID { get; set; }
        [ForeignKey("AgeGroupID")]
        public AgeGroup AgeGroup { get; set; }  // Link to Age Group

        [Required]
        public string DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }
    }

}
