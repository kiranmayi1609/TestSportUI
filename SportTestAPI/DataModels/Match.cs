using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.DataModels
{
    public class Match
    {
        [Key]
        public int MatchID { get; set; }

        [Required]
        public int TournamentID { get; set; }
        [ForeignKey("TournamentID")]
        public Tournment Tournament { get; set; }

        [Required]
        public string Player1ID { get; set; }
        [ForeignKey("Player1ID")]
        public ApplicationUser Player1 { get; set; }

        [Required]
        public string Player2ID { get; set; }
        [ForeignKey("Player2ID")]
        public ApplicationUser Player2 { get; set; }

        public string Score { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
