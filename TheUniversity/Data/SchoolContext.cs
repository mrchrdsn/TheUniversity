using Microsoft.EntityFrameworkCore;
using TheUniversity.Models;

namespace TheUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }
        public DbSet<TheUniversity.Models.Student> Student { get; set; }
        public DbSet<TheUniversity.Models.SchoolAdministrator> SchoolAdministrator { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>()
                .Ignore(t => t.OverallAverage)
                .Ignore(u => u.OverallGradePointAverage)
                .ToTable("Student");
            modelBuilder.Entity<SchoolAdministrator>().ToTable("SchoolAdministrator");
            modelBuilder.Entity<Course>()
                .Ignore(x => x.CourseAverage)
                .Ignore(y => y.CourseGradePointAverage)
                .ToTable("Course");
            modelBuilder.Entity<Assignment>().ToTable("Assignment");
            modelBuilder.Entity<HomeSchool>().ToTable("HomeSchool");
        }

        public DbSet<TheUniversity.Models.Assignment> Assignment { get; set; }

        public DbSet<TheUniversity.Models.Course> Course { get; set; }

        public DbSet<TheUniversity.Models.Enrollment> Enrollment { get; set; }

        public DbSet<TheUniversity.Models.HomeSchool> HomeSchool { get; set; }
    }
}
