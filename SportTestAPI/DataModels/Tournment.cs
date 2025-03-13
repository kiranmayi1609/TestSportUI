using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.DataModels
{
    public class Tournment
    {
        [Key]
        public int TournamentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string EventPic { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
