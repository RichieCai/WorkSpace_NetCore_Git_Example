using Microsoft.EntityFrameworkCore;
using UnitOfWorkPJEx_EF_Repository.Context;
using UnitOfWorkPJEx_EF_Repository.Interface;

namespace UnitOfWorkPJEx_EF_Repository.Repository
{
    public class UnitOfWork: IUnitOfWork,IDisposable
    {
        private DbContext _dbContext;
        //private dbTestContext _dbContext;

        public IUserRepository Users { get; }

        public UnitOfWork(dbTestContext dbcontext, IUserRepository user)
        {
            Users = user;
            _dbContext = dbcontext;
        }

        public int SaveChanges()
        { 
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
