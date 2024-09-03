using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApIJWT_Ex.Controllers
{
    [ApiController]
    //有版本號的使用方法
    //[ApiVersion("1.0")]
    //[Route("v{version:apiVersion}/[controller]/[action]")]
    //[EnableCors("NodjsEx")]曾對個別的control套用cors
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet("value1")]
        //[Route("api/value1")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value1" };
        }

        [HttpGet("value2")]
        //[Route("api/value2")]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get2()
        {
            return new string[] { "value2", "value2" };
        }
    }
}
