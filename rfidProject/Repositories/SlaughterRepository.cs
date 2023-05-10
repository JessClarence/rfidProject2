using Microsoft.EntityFrameworkCore;
using rfidProject.Core.IRepositories;
using rfidProject.Data;
using rfidProject.Models;

namespace rfidProject.Repositories
{
    public class SlaughterRepository : ISlaughterRepository
    {
        private readonly rfidProjectContext _context;
        public SlaughterRepository(rfidProjectContext context)
        {
            _context = context;
        }
        public AppUser GetUser(string id)
        {
            return _context.Users
                .Include(u => u.SlaughterHouse)
                .FirstOrDefault(u => u.Id == id);
        }

        public ICollection<AppUser> GetUsers()
        {
            return _context.Users
                .Include(x => x.SlaughterHouse)
                .ToList();
        }

        public AppUser UpdateUser(AppUser user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }
    }
}
