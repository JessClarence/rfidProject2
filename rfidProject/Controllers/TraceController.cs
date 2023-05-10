using Microsoft.AspNetCore.Mvc;
using rfidProject.Core.IRepositories;
using rfidProject.Data;
using rfidProject.Models;

namespace rfidProject.Controllers
{
    public class TraceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TraceController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(string search)
        {

            if (!string.IsNullOrEmpty(search))
            {
                var cattle = _unitOfWork.Cattle.GetCattleInfo(search);
                if (cattle != null)
                {
                    return RedirectToAction("Detail", new { id = cattle.Rfid });
                }
            }
            return View();
        }
        public IActionResult Detail(string id)
        {
            var result = _unitOfWork.Cattle.GetCattleInfo(id);
            return View(result);
        }
        
    }
}
