

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SportTestAPI.DataModels
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string FullName { get; set; }

        public string ProfilePicture { get; set; } = "";

        [Required]
        public string Role { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Contact { get; set; }  // Changed to string for better phone number handling

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }

    }
}
