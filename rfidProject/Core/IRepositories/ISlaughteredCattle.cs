using rfidProject.Models;

namespace rfidProject.Core.IRepositories
{
    public interface ISlaughteredCattle
    {
        ICollection<CattleReg> availableCattle();

        ICollection<SlaughterCattle> GetSlaughtered();

        SlaughterCattle GetCattleInfoForSlaughter(int id);

        bool Add(SlaughterCattle cattle);

        bool Delete(SlaughterCattle cattle);

        bool Save();
    }
}
