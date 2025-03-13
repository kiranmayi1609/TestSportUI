using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.Dto
{
    public class AgeGroupRequestDto
    {
        [Required]
        public string GroupName { get; set; }

        public string AvailableDays { get; set; }
    }

    public class AgeGroupResponseDto
    {
        public int AgeGroupID { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

    }
}
