namespace Kollegeni.DTOs
{
    public class BookingRequestDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BookingId { get; set; }
    }
}
