using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Tutorial.AspNetSecurity.RouxAcademy.DataServices;

namespace Tutorial.AspNetSecurity.RouxAcademy.Migrations.StudentData
{
    [DbContext(typeof(StudentDataContext))]
    [Migration("20180625002710_InitialCreateStudent")]
    partial class InitialCreateStudent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tutorial.AspNetSecurity.RouxAcademy.Models.Student.CourseGrade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("Grade");

                    b.Property<string>("ProfessorName")
                        .HasMaxLength(500);

                    b.Property<string>("StudentUsername")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });
        }
    }
}
