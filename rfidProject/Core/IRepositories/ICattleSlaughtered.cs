using rfidProject.Models;

namespace rfidProject.Core.IRepositories
{
    public interface ICattleSlaughtered
    {
        ICollection<CattleReg> GetCattles();

        ICollection<CattleReg> GetCattleFromProducer(string id);
    }
}
