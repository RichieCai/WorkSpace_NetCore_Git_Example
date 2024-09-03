using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPJEx_EF_Repository.Models.Data;

namespace UnitOfWorkPJEx_EF_Service.Interface
{
    public interface IUserService
    {
        Task<User> GetById(int UserId);

        Task<IEnumerable<User>> GetAll();
        Task<bool> CreateUser(User user);

        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(int UserId);
    }
}
