using Microsoft.EntityFrameworkCore;
using WebRestfulApiEx.Models;


namespace WebRestfulApiEx.Data
{
    public class CustomDbSampleContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public CustomDbSampleContext(DbContextOptions<CustomDbSampleContext> options) : base(options)
        {
            //using (var context = new DbContextOptions<CustomDbSampleContext>())
            //{
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Blog>().ToTable("Blog");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments");
            modelBuilder.Entity<Course>().ToTable("Course");

            
        }
        public DbSet<Post> Post { get; set; }
        public DbSet<Blog> Blog { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
