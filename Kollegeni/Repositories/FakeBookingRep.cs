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
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(4)
            },
            new Booking
            {
                Id = 2,
                StartTime = DateTime.Now.AddDays(1),
                EndTime = DateTime.Now.AddDays(1).AddHours(2)
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
