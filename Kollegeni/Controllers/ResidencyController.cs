using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kollegeni.Models;
using System.Linq;
using System.Threading.Tasks;
using Kollegeni.Data;

namespace Kollegeni.Controllers
{
    public class ResidencyController : Controller
    {
        private readonly BookingDbContext _context;

        public ResidencyController(BookingDbContext context)
        {
            _context = context;
        }

        // GET: Residency
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.Session.GetString("Username");
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var residencies = await _context.Residencies
                .Include(r => r.UserResidencies)
                .ThenInclude(ur => ur.User)
                .ToListAsync();

            return View(residencies);
        }
    }
}
