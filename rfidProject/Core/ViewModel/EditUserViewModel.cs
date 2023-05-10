using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using rfidProject.Models;

namespace rfidProject.Core.ViewModel
{
    public class EditUserViewModel
    {
        public AppUser User { get; set; }
        public AppUser Slaughter { get; set; }

        public IList<SelectListItem> Roles { get; set; }
    }
}
