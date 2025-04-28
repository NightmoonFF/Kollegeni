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
            _context.Bookinger.Add(booking);
            _context.SaveChanges();
        }
        public void UpdateBooking(Booking booking)
        {
            _context.Bookinger.Update(booking);
            _context.SaveChanges();
        }
        public void DeleteBooking(Booking booking)
        {
            _context.Bookinger.Remove(booking);
            _context.SaveChanges();
        }
        public Booking GetBookingById(int id)
        {
            return _context.Bookinger.Find(id);
        }
        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookinger.ToList();
        }   
    }
}
