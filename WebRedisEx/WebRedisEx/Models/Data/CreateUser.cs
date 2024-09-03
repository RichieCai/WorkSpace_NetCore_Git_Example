using System.Text.Json;
using WebRedisEx.ViewModels;

namespace WebRedisEx.Models.Data
{
    public static class CreateUser
    {
        public static List<UserVM> GetUser() {
            var users = new List<UserVM>();

            for (int i = 1; i <= 10; i++)
            {
                var user = new UserVM
                {
                    UserId = i,
                    UserName = $"User_{i}",
                    Age = i * 10,
                    Sex = (UserVM.eSex)(i % 2 + 1),
                    Phone = $"12345678{i}",
                    CityName = $"City_{i}"
                };

                users.Add(user);
            }
            return users;
        }
    }
}
