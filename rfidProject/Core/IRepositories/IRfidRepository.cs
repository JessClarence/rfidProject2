using rfidProject.Models;

namespace rfidProject.Core.IRepositories
{
    public interface IRfidRepository
    {
        ICollection<Rfid> GetUsers();

        string GetRfids();
    }
}
