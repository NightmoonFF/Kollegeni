using Microsoft.AspNetCore.Mvc;
using Kollegeni.Models;
using Kollegeni.Data;

namespace Kollegeni.Controllers
{
    public class ProfilePageController : Controller
    {
        private readonly BookingDbContext _context;

        public ProfilePageController(BookingDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var userId = 1; //TODO: Get actual userID of person logged in (session?)
            var user = _context.Users.Find(userId);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        public IActionResult Index(User updatedUser)
        {
            if (!ModelState.IsValid)
                return View(updatedUser);

            var user = _context.Users.Find(updatedUser.Id); // Or use userId from session?

            if (user == null)
                return NotFound();

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.Language = updatedUser.Language;
            user.Avatar = updatedUser.Avatar;

            _context.SaveChanges();

            ViewBag.Message = "Profile updated successfully.";
            return View(user);
        }
    }
}