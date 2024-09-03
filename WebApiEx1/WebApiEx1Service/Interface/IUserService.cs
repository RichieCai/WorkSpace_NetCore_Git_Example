using WebApiEx1Repository.Data;

namespace WebApiEx1Service.Interface
{
    public interface IUserService
    {
        Task<User> GetById(int UserId);

        Task<IEnumerable<User>> GetAll();

        Task<bool> AddAsync(User user);
        Task<bool> UpdateAsync(User user);

        Task<bool> DeleteAsync(int UserId);
    }
}
