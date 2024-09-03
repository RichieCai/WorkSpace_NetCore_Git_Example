namespace UnitOfWorkPJEx_EF_Repository.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        int SaveChanges();
    }
}
