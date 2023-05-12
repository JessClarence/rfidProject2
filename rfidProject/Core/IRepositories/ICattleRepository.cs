using rfidProject.Models;

namespace rfidProject.Core.IRepositories
{
    public interface ICattleRepository
    {
        ICollection<CattleReg> GetCattles();
        CattleReg GetCattleInfo(string id);
        CattleReg GetCattleInfoForSlaughter(int id);
    }
}
