namespace WebRestfulApiEx.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int Phone { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public Grade Grade { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
