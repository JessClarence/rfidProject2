
using rfidProject.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rfidProject.Models
{
    public class SlaughterCattle
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CattleReg")]
        public int CattleRegId { get; set; }
        public virtual CattleReg CattleReg { get; set; }
        public string SlaughtWeight { get; set; }
        public int Age { get; set; }
        public HealthStatus SlaughtHealthStatus { get; set; }
        public DateTime DateSlaughtered { get; set; } = DateTime.UtcNow;

    }
}
