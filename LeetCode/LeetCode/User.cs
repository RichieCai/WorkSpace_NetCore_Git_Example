using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public  class User
    {
        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public DateTime? AddDate { get; set; }
        public byte? Status { get; set; }
        public int? PermissionsId { get; set; }

        public int Age { get; set; }

        public  User()
        {


        }

        public List<User> Users { get; set; }


        public List<User?> GetData() { 
         List<User> users = new List<User>();
            users.Add(new User()
            {
                UserId ="1",
                UserName="tenny",
                AddDate = DateTime.Now,
                Status = 0,
                PermissionsId = 0,
            });

            users.Add(new User()
            {
                UserId = "2",
                UserName = "amy",
                AddDate = DateTime.Now,
                Status = 0,
                PermissionsId = 0,
            });

            users.Add(new User()
            {
                UserId = "1",
                UserName = "carry",
                AddDate = DateTime.Now,
                Status = 0,
                PermissionsId = 0,
            });
            return users;
        }

    }

}
