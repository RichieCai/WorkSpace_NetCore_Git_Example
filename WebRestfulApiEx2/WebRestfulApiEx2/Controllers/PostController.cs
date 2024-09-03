using Microsoft.AspNetCore.Mvc;

namespace WebRestfulApiEx.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
