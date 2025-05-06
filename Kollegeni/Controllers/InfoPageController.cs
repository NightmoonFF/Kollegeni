using Microsoft.AspNetCore.Mvc;

namespace Kollegeni.Controllers
{
    public class InfoPageController : Controller
    {
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("Username");
            if (user == null) {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
