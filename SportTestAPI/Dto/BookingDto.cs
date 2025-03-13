namespace SportTestAPI.Dto
{
    public class BookingRequestDto
    {
        public string UserID { get; set; }
        public int CourtID { get; set; }
        public DateTime Date { get; set; }
    }

    public class BookingResponseDto
    {
        public int BookingId { get; set; }
        public string UserID { get; set; }
        public int CourtID { get; set; }
        public DateTime Date { get; set; }
        public string CourtName { get; set; }
        public string Status { get; set; } // pending, confirmed, canceled
    }
}
