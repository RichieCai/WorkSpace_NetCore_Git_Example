
using Microsoft.AspNetCore.Mvc;
using PJXUnitTestEx.Interface;
using PJXUnitTestEx.Models.Data;

namespace PJXUnitTestEx.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("one/{UserName}")]
        public async Task<IActionResult> GetUserAsync(string UserName)
        {
            var vUsers = await _userService.GetUserAsync(UserName);
            return Ok(vUsers);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetUserAllAsync()
        {
            var result = await _userService.GetUserAllAsync();
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }



        [HttpPost("SaveAsync")]
        public async Task<IActionResult> SaveAsync(User user)
        {
            await _userService.SaveAsync(user);
            return Ok();
        }


    }
}
