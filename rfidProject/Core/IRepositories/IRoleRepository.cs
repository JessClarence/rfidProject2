using Microsoft.AspNetCore.Identity;

namespace rfidProject.Core.IRepositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
