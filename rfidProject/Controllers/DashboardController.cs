using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rfidProject.Core.IRepositories;
using rfidProject.Data;
using rfidProject.Models;

namespace rfidProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Index()
        {
            var users = _unitOfWork.Cattle.GetCattles();
            var nonNullFarmNameUsers = users.Where(u => u.Producer.FarmName != null);
            var groupByLocation = nonNullFarmNameUsers.GroupBy(u => u.Producer.FarmLocation.ToString());
            var locations = groupByLocation.Select(g => g.Key).ToList();
            var userCounts = groupByLocation.Select(g => g.Count()).ToList();
            var chartData = new { locations, userCounts };
            return View(chartData);



        }

        public IActionResult BreedChart()
        {
            var users = _unitOfWork.Cattle.GetCattles();
            var nonNullFarmNameUsers = users.Where(u => u.Producer.FarmName != null);
            var groupByLocation = nonNullFarmNameUsers.GroupBy(u => u.Breed.ToString());
            var locations = groupByLocation.Select(g => g.Key).ToList();
            var userCounts = groupByLocation.Select(g => g.Count()).ToList();
            var chartData = new { locations, userCounts };
            return View(chartData);
        }

    }
}
