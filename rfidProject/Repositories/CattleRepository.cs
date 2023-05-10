using Microsoft.EntityFrameworkCore;
using rfidProject.Core.IRepositories;
using rfidProject.Data;
using rfidProject.Models;

namespace rfidProject.Repositories
{
    public class CattleRepository : ICattleRepository
    {
        private readonly rfidProjectContext _context;

        public CattleRepository(rfidProjectContext context)
        {
            _context = context;
        }

        public CattleReg GetCattleInfo(string id)
        {
            return _context.CattleRegs
                .Include(u => u.Producer)
                .Include(u => u.SlaughterHouse)
                .FirstOrDefault(u => u.Rfid  == id);
        }

        public ICollection<CattleReg> GetCattles()
        {
            return _context.CattleRegs
                .Include(u => u.Producer)      
                .Include(u => u.SlaughterHouse)
                .ToList();
        }
    }
}
