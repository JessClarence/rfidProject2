
using rfidProject.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace rfidProject.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public string? OwnerName { get; set; }
        public string? FarmName { get; set; }
        public FarmLocation? FarmLocation { get; set; }
        public string? Description { get; set; }
        public string? ContactInfo { get; set; }
        public string? Image { get; set; }
    }
}
