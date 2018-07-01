using Microsoft.EntityFrameworkCore;
using Tutorial.AspNetSecurity.WebClient.Models.Student;

namespace Tutorial.AspNetSecurity.WebClient.DataServices
{
    public class StudentDataContext: DbContext
    {
        public DbSet<CourseGrade> Grades { get; set; }
       
        public StudentDataContext(DbContextOptions<StudentDataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
