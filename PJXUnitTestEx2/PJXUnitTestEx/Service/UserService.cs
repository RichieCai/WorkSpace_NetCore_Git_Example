//using DBChatRepository.Context;
//using DBChatRepository.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PJXUnitTestEx.Context;
using PJXUnitTestEx.Interface;
using PJXUnitTestEx.Models.Data;

namespace PJXUnitTestEx.Service
{
    public class UserService : IUserService
    {
        private readonly dbChatMSContext _context;
        public UserService(dbChatMSContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserAsync(string UserName)
        {
            var vUsers = await _context.Users.Where(x=>x.UserName==UserName).SingleAsync();
            return vUsers;
        }


        public async Task<List<User>> GetUserAllAsync()
        {
          return await _context.Users.ToListAsync();

        }
        public async Task  SaveAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
