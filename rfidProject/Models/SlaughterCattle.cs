
using rfidProject.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace rfidProject.Models
{
    public class SlaughterCattle
    {
        [Key]
        public int Id { get; set; }
        public string SlaughtWeight { get; set; }
        public int Age { get; set; }
        public HealthStatus SlaughtHealthStatus { get; set; }
        public DateTime DateSlaughtered { get; set; }
    }
}
