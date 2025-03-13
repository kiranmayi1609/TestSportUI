using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.Dto
{
    public class TrainingSessionRequestDto
    {
        [Required]
        public string UserID { get; set; }

        [Required]
        public int CoachID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Duration { get; set; }  // in minutes

        public string Location { get; set; }

        [Required]
        public decimal Fee { get; set; }

        [Required]
        public int InvoiceID { get; set; }

        [Required]
        public int AgeGroupID { get; set; }

        [Required]
        public string DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }
    }

    public class TrainingSessionResponseDto
    {
        public int SessionID { get; set; }

        public string UserID { get; set; }
        public string UserName { get; set; }  // Include User's name in the response

        public int CoachID { get; set; }
        public string CoachName { get; set; }  // Include Coach's name in the response

        public DateTime Date { get; set; }

        public int Duration { get; set; }  // in minutes

        public string Location { get; set; }

        public decimal Fee { get; set; }

        public int InvoiceID { get; set; }
        public string InvoiceReference { get; set; }  // Include Invoice reference in the response

        public int AgeGroupID { get; set; }
        public string AgeGroupName { get; set; }  // Include AgeGroup name in the response

        public string DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }
    }


}
