using Kollegeni.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kollegeni.Data;
public class BookingDbContext : DbContext
{

    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
    {

        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Residency> Residencies { get; set; }
    public DbSet<UserResidence> UserResidencies { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Kollegeni;Trusted_Connection=True;TrustServerCertificate=True;");
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


        //Seed Residencies data
        modelBuilder.Entity<Residency>().HasData(
            new Residency { Id = 1, Address = "71, 2" },
            new Residency { Id = 2, Address = "74, 5" }
        );

        //Seed Users data
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "John", Password = "123", Name = "John", Email = "john@example.com", Language = "English", Avatar = "http://example.com/avatar1.jpg" },
            new User { Id = 2, Username = "JaneSmith", Password = "123", Name = "Jane", Email = "jane@example.com", Language = "English", Avatar = "http://example.com/avatar2.jpg" },
            new User { Id = 3, Username = "Karen", Password = "123", Name = "Karen", Email = "karen@example.com", Language = "English", Avatar = "http://example.com/avatar2.jpg" }
        );

        //Seed UserResidencies data (Associating users with residencies)
        modelBuilder.Entity<UserResidence>().HasData(
            new UserResidence { UserId = 1, ResidenceId = 1 },
            new UserResidence { UserId = 2, ResidenceId = 1 },
            new UserResidence { UserId = 3, ResidenceId = 2 });

        //Seed Room Data
        modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1, Name = "Bar Room", Description = "The bar room i guess"},
            new Room { Id = 2, Name = "Pool Room", Description = "Room for playing Pool obviously"}
            );

        //Seed Booking Data
        modelBuilder.Entity<Booking>().HasData(
            new Booking
            {
                Id = 1,
                StartTime = new DateTime(2025, 05, 10, 14, 0, 0),
                EndTime = new DateTime(2025, 05, 10, 16, 0, 0),
                RoomId = 1,
                ResidencyId = 1
            },
            new Booking
            {
                Id = 2,
                StartTime = new DateTime(2025, 05, 11, 9, 0, 0),
                EndTime = new DateTime(2025, 05, 11, 11, 0, 0),
                RoomId = 2,
                ResidencyId = 1
            },
            new Booking
            {
                Id = 3,
                StartTime = new DateTime(2025, 05, 12, 18, 0, 0),
                EndTime = new DateTime(2025, 05, 12, 20, 0, 0),
                RoomId = 1,
                ResidencyId = 2
            });
        
        base.OnModelCreating(modelBuilder);
    }

}
