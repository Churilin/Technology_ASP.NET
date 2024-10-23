using Microsoft.EntityFrameworkCore;

namespace MvcStudentApp.Models
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Lesson> Lessons { get; set; }
    }
}
