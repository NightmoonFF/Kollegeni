using Microsoft.AspNetCore.Mvc;

namespace Kollegeni.Controllers
{
    public class InfoPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
