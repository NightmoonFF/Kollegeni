using Kollegeni.Interface;
using Kollegeni.Models;

namespace Kollegeni.Repositories
{
    public class FakeBookingRep : IBookingRepository
    {
        private readonly List<Booking> _bookings = new()
        {
            new Booking
            {
                BookingId = 1,
                StartTidspunkt = DateTime.Now,
                SlutTidspunkt = DateTime.Now.AddHours(4)
            },
            new Booking
            {
                BookingId = 2,
                StartTidspunkt = DateTime.Now.AddDays(1),
                SlutTidspunkt = DateTime.Now.AddDays(1).AddHours(2)
            }
        };

        public void AddBooking(Booking booking)
        {
            booking.BookingId = _bookings.Count + 1;
            _bookings.Add(booking);
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _bookings;
        }
    }   
}
