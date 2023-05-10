using Microsoft.EntityFrameworkCore;
using rfidProject.Core.IRepositories;
using rfidProject.Data;
using rfidProject.Models;

namespace rfidProject.Repositories
{
    public class CattleSlaughtered : ICattleSlaughtered
    {
        private readonly rfidProjectContext _context;

        public CattleSlaughtered(rfidProjectContext context)
        {
            _context = context;
        }
        public ICollection<CattleReg> GetCattleFromProducer(string id)
        {
            return _context.CattleRegs
            .Include(c => c.Producer)
            .Join(_context.Users,
                c => c.ProducerId,
                u => u.ProducerId,
                (c, u) => new { Cattle = c, User = u }
            )
            .Where(cu => cu.User.Id == id)
            .Select(cu => cu.Cattle)
            .ToList();
        }

        public ICollection<CattleReg> GetCattles()
        {
            throw new NotImplementedException();
        }
    }
}
