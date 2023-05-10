
using Microsoft.AspNetCore.Mvc;
using rfidProject.Models;
using System.Diagnostics;

namespace rfidProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole("Producer"))
            {
                return RedirectToAction("Index", "Producer");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole("SlaughterHouse"))
            {
                return RedirectToAction("Index", "SlaughterHouse");
            }else if(
                User.Identity.IsAuthenticated &&
                !User.IsInRole("Administrator") &&
                !User.IsInRole("Producer") &&
                !User.IsInRole("SlaughterHouse")
                )
            {
                return RedirectToAction("Privacy", "Home");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}