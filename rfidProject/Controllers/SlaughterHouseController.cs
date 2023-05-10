using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rfidProject.Models;

namespace rfidProject.Controllers
{
    public class SlaughterHouseController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SlaughterHouseController(UserManager<AppUser> userManager)
        {

            _userManager = userManager;
        }
        [Authorize(Policy = "RequireSlaughterHouse")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.Users
            .Include(u => u.SlaughterHouse)
            .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            return View(user);
        }
    }
}
