namespace Kollegeni.DTOs
{
    public class BookingRequestDto
    {
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }
        public int BookingId { get; set; }
    }
}
