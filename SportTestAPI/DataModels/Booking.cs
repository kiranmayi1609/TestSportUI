using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.DataModels
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }

        [Required]
        public int CourtID { get; set; }
        [ForeignKey("CourtID")]
        public Court Court { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
