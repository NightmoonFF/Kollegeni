using Microsoft.EntityFrameworkCore;
using Kollegeni.Models;  

namespace Kollegeni.Data
{
    public class BookingDbContext : DbContext
        
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options) { }

        public DbSet<Booking> Bookings { get; set; }

    }
}
