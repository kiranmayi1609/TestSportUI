using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.DataModels
{
    public class Court
    {
        [Key]
        public int CourtID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public string Picture { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
