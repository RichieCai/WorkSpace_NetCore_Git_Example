using Microsoft.AspNetCore.Mvc;
using WebRestfulApiEx.Models;
using WebRestfulApiEx.Data;


namespace WebRestfulApiEx.Controllers
{
    public class StudentController : Controller
    {
        CustomDbSampleContext customDbSampleContext;
        [HttpGet]
        public IEnumerable<Student> Index()
        {
            Student user = new Student();
            List<Student> listUsers = new List<Student>();
           // Student student = await _context.Students.Take(10).ToListAsync();
            return listUsers.ToArray();
        }

        [HttpPost]
        public IEnumerable<Student> Edit(User user)
        {
            List<Student> listUsers = new List<Student>();
           // using (var ctx = new CustomDbSampleContext())
           // {
           //     var stud = new Student() { StudentName = "Btll" };
           //
           //     ctx.Students.Add(stud);
           //     ctx.SaveChanges();
           // }
            return listUsers.ToArray();

        }




        [HttpPut]
        public IEnumerable<Student> Edit(int id)
        {
            Student user = new Student();
            List<Student> listUsers = new List<Student>();
            return listUsers.ToArray();
        }

        [HttpDelete]
        public IEnumerable<Student> delete(int id)
        {
            Student user = new Student();
            List<Student> listUsers = new List<Student>();
            return listUsers.ToArray();
        }
    }
}
