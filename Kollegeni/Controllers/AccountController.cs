using Kollegeni.Data;
using Kollegeni.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kollegeni.Controllers
{
    public class AccountController : Controller
    {
        private readonly BookingDbContext _context;

        public AccountController(BookingDbContext db)
        {
            _context = db;
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {

                    HttpContext.Session.SetString("Username", user.Username);
                    
                    return RedirectToAction("Index", "Calendar");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
