using fruitwala.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using fruitwala.Data;
namespace fruitwala.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AdminDashboard()
        {
            var ID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.User = _context.ApplicationUsers.Single(b => b.Id == ID);
            return View();
        }
         public IActionResult OrderHistory()
        {
            var ID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewBag.orders = _context.Order.Where(b => b.UserId == ID);

            ViewBag.User = _context.ApplicationUsers.Single(b => b.Id == ID);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}