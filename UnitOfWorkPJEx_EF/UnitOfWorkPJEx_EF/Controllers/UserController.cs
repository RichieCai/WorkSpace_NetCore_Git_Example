using Microsoft.AspNetCore.Mvc;
using UnitOfWorkPJEx_EF_Repository.Context;
using UnitOfWorkPJEx_EF_Repository.Models.Data;
using UnitOfWorkPJEx_EF_Service.Interface;

namespace UnitOfWorkPJEx_EF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iUserService;

        public UserController( IUserService iUserService)
        {
            _iUserService = iUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var UserList = await _iUserService.GetAll();
            if(UserList==null)
                return NotFound();
            return Ok(UserList);
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetById(int UserId)
        {
            var user = await _iUserService.GetById(UserId);
            if (user == null)
            { 
                return NotFound();
            }
            return Ok(user);

        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var isOk = await _iUserService.CreateUser(user);
            if (isOk)
            {
                return Ok(isOk);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {

            var isOk = await _iUserService.UpdateUser(user);
            if (isOk)
            {
                return Ok(isOk);
            }
            return BadRequest();
        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            var isOk = await _iUserService.DeleteUser(UserId);
            if (isOk)
                return Ok(isOk);
            return BadRequest(); 
        }

    }
}
