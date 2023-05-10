using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rfidProject.Core.IRepositories;
using rfidProject.Core.ViewModel;
using rfidProject.Models;

namespace rfidProject.Controllers
{
    public class ProducerController : Controller
    {
        
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public ProducerController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy = "RequireProducer")]
        public async Task<IActionResult> Index()
        {
            
            var user = await _userManager.Users
            .Include(u => u.Producer)
            .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            return View(user);
        }

        [Authorize(Policy = "RequireProducer")]
        public IActionResult SlaughterCattle()
        {
            var curUserId = HttpContext.User.GetUserId();
            var cattle = _unitOfWork.CattleSlaughtered.GetCattleFromProducer(curUserId);
            return View(cattle);
        }
    }
}
