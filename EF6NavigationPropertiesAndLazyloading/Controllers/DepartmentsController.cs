#nullable disable
namespace EFCore6Demo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly ILogger<DepartmentsController> _logger;
    private readonly ContosoUniversityContext _db;

    public DepartmentsController(ILogger<DepartmentsController> logger, ContosoUniversityContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet("")]
    public ActionResult<IEnumerable<Department>> GetDepartments()
    {
        return this._db.Departments.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Department> GetDepartmentById(int id)
    {
        return this._db.Departments.Find(id);
    }


    [HttpGet("{id}/Courses/v1")]
    public ActionResult<IEnumerable<Course>> GetDapartmentCourses(int id)
    {
        return this._db.Courses.Where(p => p.DepartmentId == id).ToList();
    }

    [HttpGet("{id}/Courses/v2")]
    public ActionResult<IEnumerable<Course>> GetDepartmentCoursesByEagerLoading(int id)
    {
        var dept = this._db.Departments.Include(dept => dept.Courses).First(x => x.DepartmentId == id);
        return dept.Courses.ToList();
    }


    [HttpGet("{id}/Courses/v3")]
    public ActionResult<IEnumerable<Course>> GetDepartmentCoursesByLazyLoading(int id)
    {
        var dept = this._db.Departments.Find(id);
        return dept.Courses.ToList();
    }


    [HttpGet("{id}/Courses/v4")]
    public ActionResult<IEnumerable<Course>> GetDepartmentCoursesByExplicitLoading(int id)
    {
        var dept = this._db.Departments.Find(id);
        this._db.Entry(dept).Collection(p => p.Courses).Load();
        return dept.Courses.ToList();
    }


    [HttpGet("~/api/Courses/{id}/Department")]
    public ActionResult<Department> GetDepartmentFromCourseByExplicitLoading(int id)
    {
        var course = this._db.Courses.Find(id);
        this._db.Entry(course).Reference(p => p.Department).Load();
        return course.Department;
    }
}
