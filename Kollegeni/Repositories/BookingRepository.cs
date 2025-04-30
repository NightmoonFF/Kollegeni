using Kollegeni.Interface;
using Kollegeni.Models;
using Kollegeni.Data;

namespace Kollegeni.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _context; 
        public BookingRepository(BookingDbContext context)
        {
            _context = context;
        }   

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }
        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }
        public void DeleteBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }
        public Booking GetBookingById(int id)
        {
            return _context.Bookings.Find(id);
        }
        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }   
    }
}
