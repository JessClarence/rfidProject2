using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rfidProject.Core.IRepositories;
using rfidProject.Core.ViewModel;
using rfidProject.Models;

namespace rfidProject.Controllers
{
    public class SlaughterCattlesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SlaughterCattlesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var availCattles = _unitOfWork.SlaughteredCattle.availableCattle();
            var slaughtered = _unitOfWork.SlaughteredCattle.GetSlaughtered();

            var cattles = new CattleForSlaughterViewModel
            {
                cattleRegs = availCattles,
                slaughters = slaughtered
            };

            return View(cattles);
        }

        public IActionResult Slaughter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCattleRegToSlaughterCattle(int cattleRegId)
        {
            
                var cattleReg = _unitOfWork.Cattle.GetCattleInfoForSlaughter(cattleRegId);
                if (cattleReg == null)
                {
                    return NotFound();
                }
                var slaughterCattle = new SlaughterCattle
                {
                    CattleReg = cattleReg,
                    SlaughtWeight = cattleReg.RegWeight,
                    Age = cattleReg.Age,
                    SlaughtHealthStatus = cattleReg.HealthStatus,
                    DateSlaughtered = DateTime.UtcNow
                };
            _unitOfWork.SlaughteredCattle.Add(slaughterCattle);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> GetSlaughterCattles()
        {
            var slaughterCattles = _unitOfWork.SlaughteredCattle.GetSlaughtered();
            return Json(slaughterCattles);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSlaughterCattle(int id)
        {
            var slaughterCattle = _unitOfWork.SlaughteredCattle.GetCattleInfoForSlaughter(id);

            if (slaughterCattle == null)
            {
                return NotFound();
            }

            _unitOfWork.SlaughteredCattle.Delete(slaughterCattle);

            return RedirectToAction(nameof(Index));
        }


    }
}
