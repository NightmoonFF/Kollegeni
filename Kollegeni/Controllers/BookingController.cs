using Microsoft.AspNetCore.Mvc;
using Kollegeni.Models;
using Kollegeni.Service;

namespace Kollegeni.Controllers
{
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var bookings = _bookingService.GetAllBookings();
            return Ok(bookings);
        }
        [HttpGet]
        public IActionResult GetBooking()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateBooking()
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBooking()
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteBooking()
        {
            return Ok();
        }
    }   
    
}
