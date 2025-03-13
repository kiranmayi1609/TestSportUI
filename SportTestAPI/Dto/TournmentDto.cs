using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.Dto
{
    public class TournamentRequestDto
    {
        [Required]
        public string Name { get; set; }  // Name of the tournament

        [Required]
        public DateTime Date { get; set; }  // Date of the tournament

        public string EventPic { get; set; }  // Optional event picture URL
    }

    public class TournamentResponseDto
    {
        public int TournamentID { get; set; }  // Unique ID of the tournament

        public string Name { get; set; }  // Name of the tournament

        public DateTime Date { get; set; }  // Date of the tournament

        public string EventPic { get; set; }  // Event picture URL

        public List<MatchResponseDto> Matches { get; set; }  // List of matches in the tournament
    }



}
