using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.DataModels
{
    public class Coach
    {
        [Key]
        public int CoachID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Specialty { get; set; }

        public string ProfilePic { get; set; }

        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}
