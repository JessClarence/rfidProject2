namespace rfidProject.Core.IRepositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }

        ISlaughterRepository Slaughter { get; }

        ICattleSlaughtered CattleSlaughtered { get; }

        ICattleRepository Cattle { get; }

        IRfidRepository Rfid { get; }

        IRoleRepository Role { get; }
    }
}
