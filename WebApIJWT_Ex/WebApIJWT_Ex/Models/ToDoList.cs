namespace WebApiJWTEx.Models
{
    public  class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string AddMid { get; set; } = null!;
        public DateTime? UpdateUid { get; set; }
        public byte Iscomplete { get; set; }
    }
}
