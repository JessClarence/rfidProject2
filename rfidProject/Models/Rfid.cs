using System.ComponentModel.DataAnnotations;

namespace rfidProject.Models
{
    public class Rfid
    {
        [Key]
        public int Id { get; set; }
        public string cardid { get; set; }
    }
}
