using Kollegeni.Models;

namespace Kollegeni.Interface
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        IEnumerable<Booking> GetAllBookings();
    }
}
