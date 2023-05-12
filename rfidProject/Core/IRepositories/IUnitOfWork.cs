namespace rfidProject.Core.IRepositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }

        ISlaughterRepository Slaughter { get; }

        ISlaughteredCattle SlaughteredCattle { get; }

        IProducerCattle CattleSlaughtered { get; }

        ICattleRepository Cattle { get; }

        IRfidRepository Rfid { get; }

        IRoleRepository Role { get; }
    }
}
