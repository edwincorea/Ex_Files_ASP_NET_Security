﻿using Microsoft.EntityFrameworkCore;
using Tutorial.AspNetSecurity.RouxAcademy.Models.Student;

namespace Tutorial.AspNetSecurity.RouxAcademy.DataServices
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
