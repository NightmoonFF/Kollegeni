using Kollegeni.Models;
using Microsoft.EntityFrameworkCore;

namespace Kollegeni.Data;
public class BookingDbContext : DbContext
{
    public BookingDbContext()
    {
    }

    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Residency> Residencies { get; set; }
    public DbSet<UserResidence> UserResidencies { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Event> Events { get; set; }

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

        base.OnModelCreating(modelBuilder);
    }
}
