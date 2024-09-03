using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPJEx_EF_Repository.Context;
using UnitOfWorkPJEx_EF_Repository.Interface;
using UnitOfWorkPJEx_EF_Repository.Models.Data;

namespace UnitOfWorkPJEx_EF_Repository.Repository
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(dbTestContext dbContext):base(dbContext)
        { 
        
        }

    }
}
