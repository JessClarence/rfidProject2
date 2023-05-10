using Microsoft.EntityFrameworkCore;
using rfidProject.Core.IRepositories;
using rfidProject.Data;
using rfidProject.Models;

namespace rfidProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly rfidProjectContext _context;
        public UserRepository(rfidProjectContext context) 
        { 
            _context = context;
        }
        public ICollection<AppUser> GetUsers()
        {
            return _context.Users.
                Include(u => u.Producer)
                .ToList();
        }

        public AppUser GetUser(string id)
        {
            return _context.Users
                .Include(u => u.Producer)
                .FirstOrDefault(u => u.Id == id);
        }

        public AppUser UpdateUser(AppUser user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }
    }
}
