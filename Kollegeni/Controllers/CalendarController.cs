using Microsoft.AspNetCore.Mvc;
using Kollegeni.Models;
using Kollegeni.Data;
using Microsoft.EntityFrameworkCore;

namespace Kollegeni.Controllers
{
    public class CalendarController : Controller
    {
        private readonly BookingDbContext _context;

        public CalendarController(BookingDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("Username");
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var rooms = _context.Rooms.ToList();
            ViewData["Rooms"] = rooms;

            return View();
        }

        public JsonResult GetBookings()
        {
            var events = _context.Bookings
                .Select(b => new
                {
                    id = b.Id,

                    start = b.StartTime.ToString("yyyy-MM-ddTHH:mm:ss"),
                    end = b.EndTime.ToString("yyyy-MM-ddTHH:mm:ss"),
                    roomId = b.RoomId,
                    residencyid = b.ResidencyId,
                    room = b.Room,
                    residency = b.Residency,
                    extendedProps = new
                    {
                        roomName = b.Room.Name
                    }

                })
                .ToList();

            return Json(events);
        }

        public JsonResult GetEvents()
        {
            var events = _context.Events
                .Select(e => new
                {
                    id = e.Id,
                    start = e.StartTime.ToString("yyyy-MM-ddTHH:mm:ss"),
                    end = e.EndTime.ToString("yyyy-MM-ddTHH:mm:ss"),
                    description = e.Description,
                    name = e.Name,
                    tenantId = e.TenantId,
                    residency = e.Residency
                })
                .ToList();

            return Json(events);
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create([Bind("RoomId")] Booking booking, string selectedDate, string timeSlot)
        {
            ModelState.Remove("Room");
            ModelState.Remove("Residency");

            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
            {
                return Json(new { success = false, message = "User not logged in." });
            }

            if (string.IsNullOrEmpty(selectedDate) || string.IsNullOrEmpty(timeSlot))
            {
                return Json(new { success = false, message = "Invalid date or time slot." });
            }

            if (!DateTime.TryParse(selectedDate + " " + timeSlot, out DateTime startTime))
            {
                return Json(new { success = false, message = "Invalid date or time format." });
            }

            try
            {
                DateTime endTime = startTime.AddHours(2);
                booking.StartTime = startTime;
                booking.EndTime = endTime;

                var user = _context.Users
                    .Include(u => u.UserResidences)
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    return Json(new { success = false, message = "User not found." });
                }

                var userResidence = user.UserResidences?.FirstOrDefault();
                if (userResidence == null)
                {
                    return Json(new { success = false, message = "User does not have a residence." });
                }

                booking.ResidencyId = userResidence.ResidenceId;

                var room = _context.Rooms.FirstOrDefault(r => r.Id == booking.RoomId);
                if (room == null)
                {
                    return Json(new { success = false, message = "Room not found." });
                }

                _context.Bookings.Add(booking);
                _context.SaveChanges();

                return Json(new { success = true, message = "Booking created successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }


        public JsonResult GetBookingDetails(int id)
        {
            var booking = GetBookingDetailsImpl(id);

            if (booking == null)
            {
                return Json(new { success = false, message = "Booking not found" });
            }

            return Json(new { success = true, data = booking });
        }

        public Booking GetBookingDetailsImpl(int id)
        {
            return _context.Bookings
                .Where(b => b.Id == id)
                .FirstOrDefault();
        }
    }
}