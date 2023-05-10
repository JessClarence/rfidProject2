
using rfidProject.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rfidProject.Models
{
    public class CattleReg
    {
        [Key]
        public int Id { get; set; }
        public string RegWeight { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Breed Breed { get; set; }
        public int Age { get; set; }
        public HealthStatus HealthStatus { get; set; }
        [ForeignKey("Producer")]
        public int? ProducerId { get; set; }
        public virtual Producer? Producer { get; set; }

        [ForeignKey("SlaughterHouse")]
        public int? SlaughterHouseId { get; set; }
        public virtual SlaughterHouse? SlaughterHouse { get; set; }
        public string Rfid { get; set; }

    }
}
