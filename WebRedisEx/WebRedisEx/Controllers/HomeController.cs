using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StackExchange.Redis;
using System.Diagnostics;
using System.Text.Json;
using WebRedisEx.Models;
using WebRedisEx.Models.Data;
using WebRedisEx.ViewModels;

namespace WebRedisEx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public HomeController(ILogger<HomeController> logger, IConnectionMultiplexer redis)
        {
            _logger = logger;
            _redis = redis;
           // _database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ActionResult<ShowVM<List<UserVM>>> User([FromQuery] string key)
        {
            ShowVM<List<UserVM>> showVM = new ShowVM<List<UserVM>>();
             var _database = _redis.GetDatabase();
            var value = _database.StringGet(key);

            if (value.HasValue )
            {
                // var result = (User)value.;
                var userJson = value.ToString();
                var users = JsonSerializer.Deserialize<List<UserVM>>(userJson);
                showVM.Method = "Cache Data";
                showVM.Data = users;
                return View(showVM);
            }
            List<UserVM> userList = CreateUser.GetUser();
            var userListJson = JsonSerializer.Serialize(userList);
            showVM.Method = "DB Data";
            showVM.Data = userList;
            _database.StringSet(key, userListJson);
            return View(showVM);
        }
        [HttpPost]
        public IActionResult RidesData(string key, string value)
        {
            var db = _redis.GetDatabase();
            db.StringSet(key, value);
            return View("",);
        }

        [HttpGet]
        public IActionResult RidesDataShow(string key)
        {
            UserVM vm = new UserVM();
            var db = _redis.GetDatabase();
            var value = db.StringGet(key);
            if (value.HasValue)
            {
                var userJson = value.ToString();
                var users = JsonSerializer.Deserialize<UserVM>(userJson);
                vm.UserName = users.UserName.ToString();
                vm.Age= Convert.ToInt32(users.Age.ToString());
            }
            return Ok(vm);
        }
    }
}