using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using rfidProject.Core.IRepositories;
using rfidProject.Core.ViewModel;
using rfidProject.Models;

namespace rfidProject.Controllers
{
    public class ListOfSlaughterHouseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<AppUser> _signInManager;
        public ListOfSlaughterHouseController(IUnitOfWork unitOfWork, SignInManager<AppUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
        }

        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Index()
        {
            var slaughter = _unitOfWork.Slaughter.GetUsers();
            return View(slaughter);
        }


        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> Edit(string id)
        {
            var slaughter = _unitOfWork.Slaughter.GetUser(id);
            var roles = _unitOfWork.Role.GetRoles();


            var userRoles = await _signInManager.UserManager.GetRolesAsync(slaughter);

            var roleItems = roles.Select(role =>
                new SelectListItem(
                    role.Name,
                    role.Id,
                    userRoles.Any(ur => ur.Contains(role.Name)))).ToList();

            var vm = new EditUserViewModel
            {
                Slaughter = slaughter,
                Roles = roleItems
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(EditUserViewModel data)
        {
            var slaughter = _unitOfWork.Slaughter.GetUser(data.Slaughter.Id);
            if (slaughter == null)
            {
                return NotFound();
            }
            var userRolesInDb = await _signInManager.UserManager.GetRolesAsync(slaughter);

            var rolesToAdd = new List<string>();
            var rolesToDelete = new List<string>();

            foreach (var role in data.Roles)
            {
                var assignedInDb = userRolesInDb.FirstOrDefault(ur => ur == role.Text);
                if (role.Selected)
                {
                    if (assignedInDb == null)
                    {
                        rolesToAdd.Add(role.Text);
                    }
                }
                else
                {
                    if (assignedInDb != null)
                    {
                        rolesToDelete.Add(role.Text);
                    }
                }
            }

            if (rolesToAdd.Any())
            {
                await _signInManager.UserManager.AddToRolesAsync(slaughter, rolesToAdd);
            }

            if (rolesToDelete.Any())
            {
                await _signInManager.UserManager.RemoveFromRolesAsync(slaughter, rolesToDelete);
            }


            slaughter.SlaughterHouse.AccreditationRate = data.Slaughter.SlaughterHouse.AccreditationRate;
            slaughter.SlaughterHouse.Location = data.Slaughter.SlaughterHouse.Location;

            _unitOfWork.Slaughter.UpdateUser(slaughter);

            return RedirectToAction("Index");
        }
    }
}
