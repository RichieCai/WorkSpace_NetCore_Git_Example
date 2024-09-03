using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTestEx_Redis.Context;
using WebTestEx_Redis.Interface;
using WebTestEx_Redis.Models;


namespace WebTestEx_Redis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext, IUserService userService)
        {
            _logger = logger;
            _dbContext = appDbContext;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add([Bind("UserName,Age,Sex,Phone,CityName")] User user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
            return RedirectToAction("UserView");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _dbContext.User.Find(id);
            if (user == null)
                return NotFound(); // 或者返回适当的错误页面
            return View(user);
        }
        public IActionResult Edit(int id, [Bind("UserName,Age,Sex,Phone,CityName")] User updatedUser)
        {
            var user = _dbContext.User.Find(id);
            if (user == null)
                return NotFound(); // 或者返回适当的错误页面

            if (ModelState.IsValid)
            {
                user.UserName = updatedUser.UserName;
                user.Age = updatedUser.Age;
                // 更新其他属性...
                _dbContext.SaveChanges();
                return RedirectToAction("UserView");
            }
            return View(updatedUser);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _dbContext.User.Find(id);
            if (user == null)
                return NotFound(); // 或者返回适当的错误页面
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _dbContext.User.Find(id);
            if (user == null)
                return NotFound(); // 或者返回适当的错误页面

            _dbContext.User.Remove(user);
            _dbContext.SaveChanges();

            return RedirectToAction("UserView");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            User user = _userService.GetOneRedisData(id);
            if (user != null)
                return View(user);

            user = _dbContext.User.Find(id);
            bool bResult = _userService.SetOneRedisData(user);
            if (user == null)
                return NotFound(); // 或者返回适当的错误页面

            return View(user);
        }

        [HttpGet]
        public IActionResult GetRedisData(int id)
        {
            User user = _userService.GetOneRedisData(id);
            return View();
        }
        [HttpGet]
        public IActionResult SetRedisData(int id)
        {
            var user = _dbContext.User.Find(id);
            bool bResult = _userService.SetOneRedisData(user);
            return View();
        }

        public IActionResult UserView()
        {
            var userList = _dbContext.User.ToList();
            return View(userList);
        }
        public IActionResult UserDetail(int UserId)
        {
            var result = _dbContext.User.Where(x => x.UserId == UserId).FirstOrDefault();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}