using rfidProject.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace rfidProject.Models
{
    public class SlaughterHouse
    {
        [Key]
        public int Id { get; set; }
        public Accreditation? AccreditationRate { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? ContactInfo { get; set; }
        public string? Image { get; set; }

    }
}
