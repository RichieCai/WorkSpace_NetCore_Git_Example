

using Generally.data;

namespace Generally.Interfaces
{
    public interface IToDoListRepository
    {
        Task<ToDoList?> Get(int id);
        Task<IEnumerable<ToDoList>> GetAll();
    }
}