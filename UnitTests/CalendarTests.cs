using Kollegeni.Controllers;
using Kollegeni.Data;
using Kollegeni.Models;
using Kollegeni.Service;
using Microsoft.AspNetCore.Http;
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
        private BookingDbContext _dbContext;
        private CalendarController _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookingDbContext>()
                .UseSqlServer("Data Source=localhost;Initial Catalog=KollegeniTest;Trusted_Connection=True;TrustServerCertificate=True;") // Use your actual test or dev database connection string
                .Options;
            _dbContext = new BookingDbContext(options);
            _controller = new CalendarController(_dbContext);
        }

        [Test]
        public void TestGetbookings()
        {

            Booking b = new Booking();
            DateTime now = DateTime.Now;
            b.StartTime = now;
            b.ResidencyId = 1;
            b.RoomId = 1;
            _dbContext.Bookings.Add(b);
            _dbContext.SaveChanges();

            Booking booking = _controller.GetBookingDetailsSimple(b.Id);
            Assert.IsNotNull(booking, "Returned booking should not be null.");
            Assert.AreEqual(b.Id, booking.Id, "Booking ID should match.");
            Assert.AreEqual(b.StartTime, booking.StartTime, "Start time should match.");
            Assert.AreEqual(b.ResidencyId, booking.ResidencyId, "Residency ID should match.");
            Assert.AreEqual(b.RoomId, booking.RoomId, "Room ID should match.");

        }

        [Test]
        public void TestCreateBooking()
        {
            var user = new User
            {
                Username = "testuser",
                UserResidences = new List<UserResidence> { new UserResidence { ResidenceId = 1 } }
            };
            var room = new Room { Id = 1, Name = "Room 1" };

            _dbContext.Users.Add(user);
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();

            _controller.ControllerContext.HttpContext.Session.SetString("Username", "testuser");

            var booking = new Booking { RoomId = 1 };
            var selectedDate = "2025-05-10";
            var timeSlot = "14:00";

            var result = _controller.Create(booking, selectedDate, timeSlot) as JsonResult;

            dynamic response = result.Value;
            Assert.IsTrue(response.success);
            Assert.AreEqual("Booking created successfully!", response.message);

            var createdBooking = _dbContext.Bookings.Find(booking.Id);
            Assert.IsNotNull(createdBooking, "The booking should be saved in the database.");
            Assert.AreEqual(booking.RoomId, createdBooking.RoomId, "The room ID should match.");
        }

        [TearDown]
        public void Cleanup()
        {
            _dbContext.Dispose();
            _controller.Dispose();
        }

    }

}
