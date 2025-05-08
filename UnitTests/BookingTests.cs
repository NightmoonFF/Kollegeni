using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class BookingTests
    {
        private RoomBookingService _bookingService;

        [SetUp]
        public void SetUp()
        {
            _bookingService = new RoomBookingService();
        }

        [Test]
        public void ShouldBookRoomSuccessfully()
        {
            var start = new DateTime(2025, 5, 1, 10, 0, 0);
            var end = new DateTime(2025, 5, 1, 12, 0, 0);

            var confirmation = _bookingService.BookRoom("Room A", start, end);

            Assert.AreEqual("Room A", confirmation.RoomName);
            Assert.AreEqual(start, confirmation.StartTime);
            Assert.AreEqual(end, confirmation.EndTime);
        }

        [Test]
        public void ShouldNotAllowDoubleBooking()
        {
            var start = new DateTime(2025, 5, 1, 10, 0, 0);
            var end = new DateTime(2025, 5, 1, 12, 0, 0);

            _bookingService.BookRoom("Room A", start, end);

            Assert.Throws<BookingConflictException>(() =>
                _bookingService.BookRoom("Room A", start, end));
        }

        [Test]
        public void ShouldNotAllowBookingWhenEndBeforeStart()
        {
            var start = new DateTime(2025, 5, 1, 12, 0, 0);
            var end = new DateTime(2025, 5, 1, 10, 0, 0);

            Assert.Throws<ArgumentException>(() =>
                _bookingService.BookRoom("Room A", start, end));
        }

        [Test]
        public void ShouldAllowBookingSameTimeInDifferentRooms()
        {
            var start = new DateTime(2025, 5, 1, 10, 0, 0);
            var end = new DateTime(2025, 5, 1, 12, 0, 0);

            var booking1 = _bookingService.BookRoom("Room A", start, end);
            var booking2 = _bookingService.BookRoom("Room B", start, end);

            Assert.AreEqual("Room A", booking1.RoomName);
            Assert.AreEqual("Room B", booking2.RoomName);
        }

        [Test]
        public void ShouldNotAllowPartialOverlap()
        {
            _bookingService.BookRoom(
                "Room A",
                new DateTime(2025, 5, 1, 10, 0, 0),
                new DateTime(2025, 5, 1, 12, 0, 0)
            );

            Assert.Throws<BookingConflictException>(() =>
                _bookingService.BookRoom(
                    "Room A",
                    new DateTime(2025, 5, 1, 11, 0, 0),
                    new DateTime(2025, 5, 1, 13, 0, 0)
                ));
        }
    }
}
}
