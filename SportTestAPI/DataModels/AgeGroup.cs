using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.DataModels
{
    public class AgeGroup
    {
        [Key]
        public int AgeGroupID { get; set; }

        [Required]
        public string GroupName { get; set; }

        public string AvailableDays { get; set; }

        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}
