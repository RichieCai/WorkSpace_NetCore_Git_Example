using WebTestEx_Redis.Models;

namespace WebTestEx_Redis.Interface
{
    public interface IUserService
    {
        User GetOneRedisData(int id);
        bool SetOneRedisData(User user);
    }
}
