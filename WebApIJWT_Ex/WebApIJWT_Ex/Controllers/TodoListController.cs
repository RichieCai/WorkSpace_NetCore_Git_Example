using Generally.data;
using Generally.Interfaces;
using Generally.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiJWTEx.CS;

namespace WebApiJWTEx.Controllers
{
    [ApiController]
    //有版本號的使用方法
    //[ApiVersion("1.0")]
    //[Route("v{version:apiVersion}/[controller]/[action]")]
    //[EnableCors("NodjsEx")]曾對個別的control套用cors
    [Route("api/[controller]")]
    public class TodoListController : Controller
    {
        private readonly IToDoListRepository _todoListRepository;

        public TodoListController( IToDoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }
        [Authorize]
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<ToDoList> listToDoList = await _todoListRepository.GetAll();
                return Ok(listToDoList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "存取資料時發生錯誤");
            }
        }


        //[TypeFilter(typeof(Filters.ActionFilter))]
        //[MiddlewareFilter(typeof(Middleware.ReqHeaderChecker))]
        //[HttpHead]
        [HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        public async Task<ActionResult<ToDoList>> Get(int id)
        {
            try
            {
                ToDoList? tdl = await _todoListRepository.Get(id);
                if (tdl == null)
                {
                    return NotFound();
                }
                return Ok(tdl);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "存取資料時發生錯誤");
            }
        }

        [HttpGet("GetIDTest")]
        public async Task<ActionResult<ToDoList>> GetIDTest(int id)
        {
            try
            {
                IEnumerable<ToDoList> tdllist = await _todoListRepository.GetAll();
                ToDoList tdl= tdllist.Where(x => x.Id == id).FirstOrDefault();
                if (tdl == null)
                {
                    return NotFound();
                }
                return Ok(tdl);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "存取資料時發生錯誤");
            }
        }
    }
}
