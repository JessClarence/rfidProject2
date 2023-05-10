using Microsoft.AspNetCore.Identity;
using rfidProject.Core.IRepositories;
using rfidProject.Data;

namespace rfidProject.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly rfidProjectContext _context;

        public RoleRepository(rfidProjectContext context) 
        {
            _context = context;
        }
        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
