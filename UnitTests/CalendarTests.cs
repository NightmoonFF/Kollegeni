using Kollegeni.Controllers;
using Kollegeni.Data;
using Kollegeni.Models;
using Kollegeni.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Kollegeni.Tests
{

    class CalendarTests
    {
        [Test]
        public void TestGetbookings()
        {
            var options = new DbContextOptionsBuilder<BookingDbContext>()
                .UseSqlServer("Data Source=localhost;Initial Catalog=KollegeniTest;Trusted_Connection=True;TrustServerCertificate=True;") // Use your actual test or dev database connection string
                .Options;
            BookingDbContext _dbContext = new BookingDbContext(options);
            CalendarController _controller = new CalendarController(_dbContext);
            
            Booking b = new Booking();
            DateTime now = DateTime.Now;
            b.StartTime = now;
            b.ResidencyId = 1;
            b.RoomId = 1;
            _dbContext.Bookings.Add(b);
            _dbContext.SaveChanges();

            Booking booking = _controller.GetBookingDetailsImpl(1);
            Assert.AreEqual(1, booking.Id);



            //var bookings = JsonSerializer.Deserialize<Booking[]>(x);


            //Assert.AreEqual(now, result[bookings.Length-1].StartTime);
            
           

        }
    }

}
