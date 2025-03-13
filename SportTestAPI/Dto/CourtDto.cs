using System.ComponentModel.DataAnnotations;

namespace SportTestAPI.Dto
{
    public class CourtRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public string Picture { get; set; }  // Optional field, may not be required for every Court
    }

    public class CourtResponseDto
    {
        public int CourtID { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Picture { get; set; }

        public List<BookingResponseDto> Bookings { get; set; }  // Optionally include related Bookings
    }


}
