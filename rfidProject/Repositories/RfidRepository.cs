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

        public Rfid GetLatestRfid()
        {
            return _context.Rfids.OrderByDescending(c => c.Id).FirstOrDefault();
        }

        public string GetRfids()
        {
            var usedRfids = _context.CattleRegs.Select(c => c.Rfid).ToList();
            var unusedRfid = _context.Rfids
                .FirstOrDefault(r => !usedRfids.Contains(r.cardid));

            return unusedRfid?.cardid;
        }

        public ICollection<Rfid> GetUsers()
        {
            return _context.Rfids.ToList();
        }
    }
}
