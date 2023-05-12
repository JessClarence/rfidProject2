using rfidProject.Models;

namespace rfidProject.Core.IRepositories
{
    public interface IProducerCattle
    {
        ICollection<CattleReg> GetCattles();

        ICollection<CattleReg> GetCattleFromProducer(string id);
    }
}
