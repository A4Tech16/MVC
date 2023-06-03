using System.Threading.Tasks;
using EFAutoSalon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ASPNETAutoSalon.Controllers
{
    public class HomeController : Controller
    {
        ApplContext db;

        public HomeController(ApplContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Buyers.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Buyer buyer)
        {
            if (buyer != null)
            {
                db.Buyers.Add(buyer);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> IndexC()
        {
            return View(await db.Cars.ToListAsync());
        }
        public IActionResult CreateC()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateM(Car car)
        {
            if (car != null)
            {
                db.Cars.Add(car);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("IndexM");
        }
    }
}