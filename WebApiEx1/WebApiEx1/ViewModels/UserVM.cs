using static WebApiEx1Repository.Data.User;

namespace WebApiEx1.ViewModels
{
    public class UserVM 
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int? Age { get; set; }
        public eSex Sex { get; set; }
        public string? Phone { get; set; }
        public string? CityName { get; set; }
    }
}
