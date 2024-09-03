using Microsoft.AspNetCore.Mvc;

namespace WebRestfulApiEx.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        public IEnumerable<User> Index()
        {
            User user = new User();
            List<User> listUsers= user.getData();
            return listUsers.ToArray();
        }

        [HttpPost]
        public IEnumerable<User> Edit(User user)
        {
            List<User> listUsers = user.getData();
            return listUsers.ToArray();
        }


        [HttpPut]
        public IEnumerable<User> Edit(int id)
        {
            User user = new User();
            List<User> listUsers = user.getData();
            return listUsers.ToArray();
        }

        [HttpDelete]
        public IEnumerable<User> delete(int id)
        {
            User user = new User();
            List<User> listUsers = user.getData();
            return listUsers.ToArray();
        }
    }
}
