using Kollegeni.Data;
using Kollegeni.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kollegeni.Controllers
{
    public class AccountController : Controller
    {
        private readonly BookingDbContext _context;

        public AccountController()
        {
            _context = new BookingDbContext();
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //TODO: virker ikke med .net Core, man skal åbenbart bruge noget identity noget - som kræver .net 9.0?
        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    // You can set up authentication cookies or tokens here
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Home"); // Redirect to Home page after login
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
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
