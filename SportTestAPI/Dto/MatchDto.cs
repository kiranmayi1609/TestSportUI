using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.Dto
{
    public class MatchRequestDto
    {
        [Required]
        public int TournamentID { get; set; }  // The ID of the tournament to which the match belongs.

        [Required]
        public string Player1ID { get; set; }  // The ID of the first player in the match.

        [Required]
        public string Player2ID { get; set; }  // The ID of the second player in the match.

        public string Score { get; set; }  // The score of the match.

        [Required]
        public DateTime Date { get; set; }  // The date and time when the match will occur.
    }

    public class MatchResponseDto
    {
        public int MatchID { get; set; }  // Unique identifier for the match.

        public int TournamentID { get; set; }  // The tournament ID to which the match belongs.

        public string Player1ID { get; set; }  // The ID of the first player.

        public string Player1Name { get; set; }  // The name of the first player (optional to include in the response).

        public string Player2ID { get; set; }  // The ID of the second player.

        public string Player2Name { get; set; }  // The name of the second player (optional to include in the response).

        public string Score { get; set; }  // The score of the match.

        public DateTime Date { get; set; }  // The date and time when the match occurred.
    }




}
