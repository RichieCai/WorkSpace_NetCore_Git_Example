using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testModel.Models;

namespace testModel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DelPage()
        {
            showdata data = new showdata();
            List<Show> listshow = data.getData();
            ShowVM svm=new ShowVM();
            svm.Id = 1000;
            svm.Name = "my test";
            svm.listShow = listshow;
            return View(svm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Show(ShowVM show)
        {

            return View(show);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}