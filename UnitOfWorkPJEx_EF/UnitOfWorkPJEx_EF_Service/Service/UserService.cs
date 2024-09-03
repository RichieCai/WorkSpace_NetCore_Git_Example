using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPJEx_EF_Repository.Interface;
using UnitOfWorkPJEx_EF_Repository.Models.Data;
using UnitOfWorkPJEx_EF_Service.Interface;

namespace UnitOfWorkPJEx_EF_Service.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetById(int UserId)
        {
            if (UserId > 0)
            {
                var Userlist = _unitOfWork.Users.Get(x=>x.UserId== UserId);
                var user = Userlist.SingleOrDefault();
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var userlist = _unitOfWork.Users.GetAll();
            return userlist;
        }

        public async Task<bool> CreateUser(User user)
        {
            if (user != null)
            {
                _unitOfWork.Users.Add(user);
                var iResult = _unitOfWork.SaveChanges();

                return (iResult > 0) ? true : false;
            }
            return false;

        }

        public async Task<bool> UpdateUser(User user)
        {
            if (user != null)
            {
                _unitOfWork.Users.Update(user);
                var iResult=_unitOfWork.SaveChanges();
                return (iResult > 0) ? true : false;
            }
            return false;

        }

        public async Task<bool> DeleteUser(int UserId) 
        {
            if (UserId > 0)
            {
                var user = _unitOfWork.Users.Get(x=>x.UserId== UserId).FirstOrDefault();
                if (user != null)
                {
                    _unitOfWork.Users.Delete(user);
                    var iResult = _unitOfWork.SaveChanges();
                    return (iResult > 0) ? true : false;
                }
            }
            return false;
        }
    }
}
