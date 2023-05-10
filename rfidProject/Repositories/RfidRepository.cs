using rfidProject.Core.IRepositories;
using rfidProject.Data;
using rfidProject.Models;

namespace rfidProject.Repositories
{
    public class RfidRepository : IRfidRepository
    {
        private readonly rfidProjectContext _context;
        public RfidRepository(rfidProjectContext context) {
            _context = context;
        }

        public string GetRfids()
        {
            var unusedRfid = _context.Rfids
        .Where(r => !_context.CattleRegs.Any(c => c.Rfid == r.cardid))
        .OrderBy(u => u.Id)
        .LastOrDefault();

            return unusedRfid?.cardid;
        }

        public ICollection<Rfid> GetUsers()
        {
            return _context.Rfids.ToList();
        }
    }
}
