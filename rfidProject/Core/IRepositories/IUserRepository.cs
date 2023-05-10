using rfidProject.Models;

namespace rfidProject.Core.IRepositories
{
    public interface IUserRepository
    {
        ICollection<AppUser> GetUsers();
        AppUser GetUser(string id);
        AppUser UpdateUser(AppUser user);
    }
}
