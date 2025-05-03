using Kollegeni.Models;
using Microsoft.EntityFrameworkCore;

namespace Kollegeni.Data;
public class BookingDbContext : DbContext
{
    public BookingDbContext()
    {
    }

    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { 
        
        Database.EnsureCreated();

    } 

    public DbSet<User> Users { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Residency> Residencies { get; set; }
    public DbSet<UserResidence> UserResidencies { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=localhost;Database=Kollegeni;Trusted_Connection=True;TrustServerCertificate=True;");
        
        //Apple Friendly
        optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Kollegeni;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite key i BrugerResidens
        modelBuilder.Entity<UserResidence>()
            .HasKey(br => new { br.UserId, br.ResidenceId });

        // Relationer
        modelBuilder.Entity<UserResidence>()
            .HasOne(br => br.User)
            .WithMany(b => b.UserResidences)
            .HasForeignKey(br => br.UserId);

        modelBuilder.Entity<UserResidence>()
            .HasOne(br => br.Residency)
            .WithMany(r => r.UserResidencies)
            .HasForeignKey(br => br.ResidenceId);
        
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Residency)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.ResidencyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Room)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Cascade);
        


        base.OnModelCreating(modelBuilder);
    }
}
