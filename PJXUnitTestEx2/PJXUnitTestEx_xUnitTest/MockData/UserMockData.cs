using PJXUnitTestEx.Models.Data;

namespace PJXUnitTestEx_xUnitTest.MockData
{
    public class UserMockData
    {
        public static User GetUser(string sUserName)
        {
            return new User()
            {
                UserId = "MEM2022112400001",
                UserName = "merry",
                AddDate = DateTime.Now,
                Status = 1,
                PermissionsId = 1
            };
        }

        public static List<User> GetUserAll()
        {
            return new List<User>()
            {
            new User()
            {
                UserId = "MEM2022112400001",
                UserName = "korea",
                AddDate = DateTime.Now,
                Status = 1,
                PermissionsId = 1
            },
             new User()
            {
                UserId = "MEM2022112400002",
                UserName = "jenny",
                AddDate = DateTime.Now,
                Status = 1,
                PermissionsId = 2
            },
              new User()
            {
                UserId = "MEM2022112400003",
                UserName = "amy",
                AddDate = DateTime.Now,
                Status = 1,
                PermissionsId = 3
            },

        };

        }

        public static List<User> EmptyUserAll()
        {
            return new List<User>();
        }
        public static User AddUser()
        {
            return new User()
            {
                UserId = "MEM2022112400004",
                UserName = "amy",
                AddDate = DateTime.Now,
                Status = 1,
                PermissionsId = 3
            };
        }
    }
}
