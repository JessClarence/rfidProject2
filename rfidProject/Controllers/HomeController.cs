
using Microsoft.AspNetCore.Mvc;
using rfidProject.Core.IRepositories;
using rfidProject.Models;
using System.Diagnostics;

namespace rfidProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string search)
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
            if (!string.IsNullOrEmpty(search))
            {
                var cattle = _unitOfWork.Cattle.GetCattleInfo(search);
                if (cattle != null)
                {
                    return RedirectToAction("Details", new { id = cattle.Rfid });
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details(string id)
        {
            var result = _unitOfWork.Cattle.GetCattleInfo(id);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}