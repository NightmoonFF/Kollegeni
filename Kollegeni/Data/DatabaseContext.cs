using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Kollegeni.Models;

namespace Kollegeni.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(): base("Kollegeni") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Residency> Residency { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }


}
