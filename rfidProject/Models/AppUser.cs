using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace rfidProject.Models
{
    public class AppUser : IdentityUser
    {
        [ForeignKey("SlaughterHouse")]
        public int? SlaughterHouseId { get; set; }
        public SlaughterHouse? SlaughterHouse { get; set; }
        [ForeignKey("Producer")]
        public int? ProducerId { get; set; }
        public Producer? Producer { get; set; }
        
    }
    public class ApplicationRole : IdentityRole
    {

    }
}
