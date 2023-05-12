using Microsoft.EntityFrameworkCore;
using rfidProject.Core.IRepositories;
using rfidProject.Data;
using rfidProject.Models;

namespace rfidProject.Repositories
{
    public class SlaughteredCattle : ISlaughteredCattle
    {
        private readonly rfidProjectContext _context;

        public SlaughteredCattle(rfidProjectContext context)
        {
            _context = context;
        }

        public bool Add(SlaughterCattle cattle)
        {
            _context.Add(cattle);
            return Save();
        }

        public ICollection<CattleReg> availableCattle()
        {
            var availCattle = _context.CattleRegs
        .Include(u => u.Producer)
        .Where(r => !_context.SlaughterCattles.Any(c => c.CattleRegId== r.Id))
        .OrderBy(u => u.Id)
        .ToList();

            return availCattle;
        }

        public bool Delete(SlaughterCattle cattle)
        {
            _context.Remove(cattle);
            return Save();
        }

        public SlaughterCattle GetCattleInfoForSlaughter(int id)
        {
            return _context.SlaughterCattles
                .Include(u => u.CattleReg)
                .FirstOrDefault(u => u.CattleRegId == id);
        }

        public ICollection<SlaughterCattle> GetSlaughtered()
        {
            return _context.SlaughterCattles
                                 .Include(sc => sc.CattleReg)
                                  .ThenInclude(cr => cr.Producer)
                                  .Include(sc => sc.CattleReg)
                                  .ThenInclude(cr => cr.SlaughterHouse)
                                  .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
