using rfidProject.Models;

namespace rfidProject.Core.ViewModel
{
    public class CattleForSlaughterViewModel
    {
        public IEnumerable<CattleReg> cattleRegs { get; set; }
        public IEnumerable<SlaughterCattle> slaughters { get; set;}
    }
}
