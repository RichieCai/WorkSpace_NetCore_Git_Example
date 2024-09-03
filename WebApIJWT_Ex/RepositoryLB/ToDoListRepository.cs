using Generally;
using Microsoft.Extensions.Configuration;
using WebApiJWTEx.Models;

namespace ToDoListRepository
{
    public class ToDoListRepository
    {
        MsDBConn _DBconn = null;
        private readonly IConfiguration _config;
        public ToDoListRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<ToDoList?> Get(int id)
        {
            _DBconn = new MsDBConn(_config);
            var sqlCmd = @" select * from ToDoList where id=@id";
            var parameter = new { Id = id };
            var result = await _DBconn.LoadData<ToDoList, dynamic>(sqlCmd, parameter);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ToDoList>> GetAll()
        {
            _DBconn = new MsDBConn(_config);
            var sqlCmd = @" select * from ToDoList ";
            var result = await _DBconn.LoadData<ToDoList>(sqlCmd);
            return result;
        }
    }



}