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
                Id = 1,
                Starttidspunkt = DateTime.Now,
                Sluttidspunkt = DateTime.Now.AddHours(4)
            },
            new Booking
            {
                Id = 2,
                Starttidspunkt = DateTime.Now.AddDays(1),
                Sluttidspunkt = DateTime.Now.AddDays(1).AddHours(2)
            }
        };

        public void AddBooking(Booking booking)
        {
            booking.Id = _bookings.Count + 1;
            _bookings.Add(booking);
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _bookings;
        }
    }   
}
