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

        //public JsonResult GetEvents()
        //{
        //    var events = _context.Events
        //        .Select(e => new
        //        {
        //            id = e.Id,
        //            start = e.StartTime.ToString("yyyy-MM-ddTHH:mm:ss"),
        //            end = e.EndTime.ToString("yyyy-MM-ddTHH:mm:ss"),
        //            description = e.Description,
        //            name = e.Name,
        //            tenantId = e.TenantId,
        //            residency = e.Residency
        //        })
        //        .ToList();

        //    return Json(events);
        //}
    }
}