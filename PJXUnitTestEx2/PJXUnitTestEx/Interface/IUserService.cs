//using DBChatRepository.Models.Data;
using Microsoft.AspNetCore.Mvc;
using PJXUnitTestEx.Models.Data;

namespace PJXUnitTestEx.Interface
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string UserName);

        Task<List<User>> GetUserAllAsync();

        Task SaveAsync(User user);
    }
}
