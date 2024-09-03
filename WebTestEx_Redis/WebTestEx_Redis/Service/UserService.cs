using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StackExchange.Redis;
using WebTestEx_Redis.Interface;
using WebTestEx_Redis.Models;

namespace WebTestEx_Redis.Service
{
    public class UserService: IUserService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public UserService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }
        public User GetOneRedisData(int id)
        {
            IDatabase db = _connectionMultiplexer.GetDatabase();
            // 檢查鍵的資料型別
            //var keyType = db.KeyType("myData_" + id);

            //if (keyType == RedisType.String)
            {
                var serializedValue = db.StringGet("myData_" + id);
                if (serializedValue.HasValue)
                {
                    return JsonConvert.DeserializeObject<User>(serializedValue);
                }
            }
            return null;
        }
        public bool SetOneRedisData(User user)
        {
            var db = _connectionMultiplexer.GetDatabase(0);
            var serializedValue = JsonConvert.SerializeObject(user);
            bool bResult = db.StringSet("myData_"+ user.UserId, serializedValue);
            return bResult;
        }

    }
}
