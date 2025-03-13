using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.Dto
{
    public class CoachRequestDto
    {
        [Required]
        public string Name { get; set; }

        public string Specialty { get; set; }

        public string ProfilePic { get; set; } // Optional, for uploading or updating profile picture
    }

    public class CoachResponseDto
    {
        public int CoachID { get; set; }

        public string Name { get; set; }

        public string Specialty { get; set; }

        public string ProfilePic { get; set; }

        public ICollection<TrainingSessionResponseDto> TrainingSessions { get; set; }
    }
}
