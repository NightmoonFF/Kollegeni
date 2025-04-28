using Kollegeni.Models;
using Microsoft.EntityFrameworkCore;

namespace Kollegeni.Data;
public class BookingDbContext : DbContext
{
    public BookingDbContext()
    {
    }

    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

    public DbSet<Bruger> Brugere { get; set; }
    public DbSet<Beboer> Beboere { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Residens> Residenser { get; set; }
    public DbSet<BrugerResidens> BrugerResidenser { get; set; }
    public DbSet<Fælleslokale> Fælleslokaler { get; set; }
    public DbSet<Booking> Bookinger { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite key i BrugerResidens
        modelBuilder.Entity<BrugerResidens>()
            .HasKey(br => new { br.BrugerId, br.ResidensId });

        // Relationer
        modelBuilder.Entity<BrugerResidens>()
            .HasOne(br => br.Bruger)
            .WithMany(b => b.BrugerResidenser)
            .HasForeignKey(br => br.BrugerId);

        modelBuilder.Entity<BrugerResidens>()
            .HasOne(br => br.Residens)
            .WithMany(r => r.BrugerResidenser)
            .HasForeignKey(br => br.ResidensId);

        base.OnModelCreating(modelBuilder);
    }
}
