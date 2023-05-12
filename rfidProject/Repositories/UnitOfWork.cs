using rfidProject.Core.IRepositories;

namespace rfidProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }

        public ISlaughterRepository Slaughter { get; }

        public ICattleRepository Cattle { get; }

        public ISlaughteredCattle SlaughteredCattle { get; }

        public IRfidRepository Rfid { get; }

        public IRoleRepository Role { get; }

        public IProducerCattle CattleSlaughtered { get; }

        public UnitOfWork(
            IUserRepository user, 
            ISlaughterRepository slaughter, 
            IRoleRepository role, 
            IRfidRepository rfid, 
            ICattleRepository cattle,
            IProducerCattle cattleSlaughtered,
            ISlaughteredCattle slaughteredCattle)
        {
            User = user;
            Slaughter = slaughter;
            Role = role;
            Rfid = rfid;
            Cattle = cattle;
            CattleSlaughtered = cattleSlaughtered;
            SlaughteredCattle = slaughteredCattle;
        }
    }
}
