using Microsoft.AspNetCore.Mvc;
using Kollegeni.Models;
using Kollegeni.Data;

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
                    residency = b.Residency

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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("StartTime,EndTime,RoomId,ResidencyId")] Booking booking, string selectedDate, string timeSlot)
        {
            // Validate data
            if (string.IsNullOrEmpty(selectedDate) || string.IsNullOrEmpty(timeSlot))
            {
                return Json(new { success = false, message = "Invalid date or time slot." });
            }

            try
            {
                // Convert selected date and time slot to DateTime
                DateTime startTime = DateTime.Parse(selectedDate + " " + timeSlot);
                DateTime endTime = startTime.AddHours(2);

                booking.StartTime = startTime;
                booking.EndTime = endTime;

                var room = _context.Rooms.FirstOrDefault(r => r.Id == booking.RoomId);
                var residency = _context.Residencies.FirstOrDefault(r => r.Id == booking.ResidencyId);

                if (room == null || residency == null)
                {
                    return Json(new { success = false, message = "Room or Residency not found." });
                }

                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return Json(new { success = true, message = "Booking created successfully!" });
            }
            catch(Exception ex) 
            {
            
                return Json(new { success = false, message = "Error: " + ex.Message });
            }

        }
    }
}