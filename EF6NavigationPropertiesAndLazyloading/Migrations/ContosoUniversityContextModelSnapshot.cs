﻿// <auto-generated />
using System;
using EFCore6Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore6Demo.Migrations
{
    [DbContext(typeof(ContosoUniversityContext))]
    partial class ContosoUniversityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CourseID");

                    b.Property<int>("InstructorId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("InstructorID");

                    b.HasKey("CourseId", "InstructorId")
                        .HasName("PK_dbo.CourseInstructor");

                    b.HasIndex(new[] { "CourseId" }, "IX_CourseID");

                    b.HasIndex(new[] { "InstructorId" }, "IX_InstructorID");

                    b.ToTable("CourseInstructor", (string)null);
                });

            modelBuilder.Entity("EFCore6Demo.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CourseID");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("DepartmentID")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("CourseId");

                    b.HasIndex(new[] { "DepartmentId" }, "IX_DepartmentID");

                    b.ToTable("Course", (string)null);

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            Credits = 1,
                            DepartmentId = 5,
                            Title = "Entity Framework 6 開發實戰"
                        },
                        new
                        {
                            CourseId = 2,
                            Credits = 1,
                            DepartmentId = 5,
                            Title = "Git新手入門"
                        },
                        new
                        {
                            CourseId = 3,
                            Credits = 2,
                            DepartmentId = 5,
                            Title = "Git進階版控流程"
                        },
                        new
                        {
                            CourseId = 4,
                            Credits = 5,
                            DepartmentId = 1,
                            Title = "ASP.NET MVC 5 開發實戰"
                        });
                });

            modelBuilder.Entity("EFCore6Demo.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("DepartmentID");

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("InstructorID");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("DepartmentId");

                    b.HasIndex(new[] { "InstructorId" }, "IX_InstructorID")
                        .HasDatabaseName("IX_InstructorID1");

                    b.ToTable("Department", (string)null);

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            Budget = 1000m,
                            Name = "教育訓練部",
                            StartDate = new DateTime(2022, 4, 20, 23, 38, 36, 372, DateTimeKind.Local).AddTicks(1250)
                        },
                        new
                        {
                            DepartmentId = 2,
                            Budget = 1000m,
                            Name = "人事行政部",
                            StartDate = new DateTime(2022, 4, 20, 23, 38, 36, 372, DateTimeKind.Local).AddTicks(1276)
                        },
                        new
                        {
                            DepartmentId = 5,
                            Budget = 1000m,
                            Name = "專案開發部",
                            StartDate = new DateTime(2022, 4, 20, 23, 38, 36, 372, DateTimeKind.Local).AddTicks(1319)
                        },
                        new
                        {
                            DepartmentId = 13,
                            Budget = 1000m,
                            Name = "產品開發部",
                            StartDate = new DateTime(2022, 4, 20, 23, 38, 36, 372, DateTimeKind.Local).AddTicks(1325)
                        });
                });

            modelBuilder.Entity("EFCore6Demo.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("EnrollmentID");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CourseID");

                    b.Property<int?>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("StudentID");

                    b.HasKey("EnrollmentId");

                    b.HasIndex(new[] { "CourseId" }, "IX_CourseID")
                        .HasDatabaseName("IX_CourseID1");

                    b.HasIndex(new[] { "StudentId" }, "IX_StudentID");

                    b.ToTable("Enrollment", (string)null);
                });

            modelBuilder.Entity("EFCore6Demo.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("InstructorID");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("InstructorId")
                        .HasName("PK_dbo.OfficeAssignment");

                    b.HasIndex(new[] { "InstructorId" }, "IX_InstructorID")
                        .HasDatabaseName("IX_InstructorID2");

                    b.ToTable("OfficeAssignment", (string)null);
                });

            modelBuilder.Entity("EFCore6Demo.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("('Instructor')");

                    b.Property<DateTime?>("EnrollmentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("EFCore6Demo.Models.VwCourseStudent", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CourseID");

                    b.Property<string>("CourseTitle")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("StudentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("StudentID");

                    b.Property<string>("StudentName")
                        .HasMaxLength(101)
                        .HasColumnType("TEXT");

                    b.ToView("vwCourseStudents");
                });

            modelBuilder.Entity("EFCore6Demo.Models.VwCourseStudentCount", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CourseID");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("StudentCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.ToView("vwCourseStudentCount");
                });

            modelBuilder.Entity("EFCore6Demo.Models.VwDepartmentCourseCount", b =>
                {
                    b.Property<int?>("CourseCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.ToView("vwDepartmentCourseCount");
                });

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.HasOne("EFCore6Demo.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.CourseInstructor_dbo.Course_CourseID");

                    b.HasOne("EFCore6Demo.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.CourseInstructor_dbo.Instructor_InstructorID");
                });

            modelBuilder.Entity("EFCore6Demo.Models.Course", b =>
                {
                    b.HasOne("EFCore6Demo.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.Course_dbo.Department_DepartmentID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EFCore6Demo.Models.Department", b =>
                {
                    b.HasOne("EFCore6Demo.Models.Person", "Instructor")
                        .WithMany("Departments")
                        .HasForeignKey("InstructorId")
                        .HasConstraintName("FK_dbo.Department_dbo.Instructor_InstructorID");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("EFCore6Demo.Models.Enrollment", b =>
                {
                    b.HasOne("EFCore6Demo.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.Enrollment_dbo.Course_CourseID");

                    b.HasOne("EFCore6Demo.Models.Person", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.Enrollment_dbo.Person_StudentID");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EFCore6Demo.Models.OfficeAssignment", b =>
                {
                    b.HasOne("EFCore6Demo.Models.Person", "Instructor")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("EFCore6Demo.Models.OfficeAssignment", "InstructorId")
                        .IsRequired()
                        .HasConstraintName("FK_dbo.OfficeAssignment_dbo.Instructor_InstructorID");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("EFCore6Demo.Models.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("EFCore6Demo.Models.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EFCore6Demo.Models.Person", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Enrollments");

                    b.Navigation("OfficeAssignment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
