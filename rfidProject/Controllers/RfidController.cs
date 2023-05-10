using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rfidProject.Core.IRepositories;

namespace rfidProject.Controllers
{
    public class RfidController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RfidController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var users = _unitOfWork.Rfid.GetUsers();
            return View(users);
        }

        public JsonResult GetRfidData()
        {
            var users = _unitOfWork.Rfid.GetUsers();
            return Json(users);
        }
    }
}
