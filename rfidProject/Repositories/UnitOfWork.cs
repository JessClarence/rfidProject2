using rfidProject.Core.IRepositories;

namespace rfidProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }

        public ISlaughterRepository Slaughter { get; }

        public ICattleRepository Cattle { get; }

        public IRfidRepository Rfid { get; }

        public IRoleRepository Role { get; }

        public ICattleSlaughtered CattleSlaughtered { get; }

        public UnitOfWork(
            IUserRepository user, 
            ISlaughterRepository slaughter, 
            IRoleRepository role, 
            IRfidRepository rfid, 
            ICattleRepository cattle,
            ICattleSlaughtered cattleSlaughtered)
        {
            User = user;
            Slaughter = slaughter;
            Role = role;
            Rfid = rfid;
            Cattle = cattle;
            CattleSlaughtered = cattleSlaughtered;
        }
    }
}
