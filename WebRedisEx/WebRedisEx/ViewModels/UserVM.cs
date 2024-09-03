using System.ComponentModel;

namespace WebRedisEx.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }
        [DisplayName("使用者名稱")]
        public string? UserName { get; set; }
        public int? Age { get; set; }
        public eSex Sex { get; set; }
        public string? Phone { get; set; }
        public string? CityName { get; set; }

        public enum eSex
        {
            male = 1,
            female = 2

        }
    }
}
