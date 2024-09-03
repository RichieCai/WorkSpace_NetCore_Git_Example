using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebRestfulApiEx.Models;

namespace WebRestfulApiEx.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomDbSampleContext(serviceProvider.GetRequiredService<
                 DbContextOptions<CustomDbSampleContext>>()))
            {

                if (context.Blog.Any())
                {
                    return;   // DB has been seeded
                }
                else
                {
                    var blog = new Blog[]
                    {
                        new Blog{Url="http://taewesad.com",Rating=213},
                        new Blog{Url="http://asasytuysad.com",Rating=55},
                        new Blog{Url="http://ffdyyttdsad.com",Rating=66},
                        new Blog{Url="http://sdsqwrrdsad.com",Rating=752},
                        new Blog{Url="http://wqdsad.com",Rating=223},
                        new Blog{Url="http://sdfddydsad.com",Rating=813},
                    };
                    context.Blog.AddRange(blog);
                    context.SaveChanges();
                }
                //// Look for any movies.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }
                else
                {
                    var students = new Student[]
                    {
                        new Student{StudentName="Carson",Height=182,Weight =21,Phone=0921288882,DateOfBirth=DateTime.Parse("2019-09-01")},
                        new Student{StudentName="Meredith",Height=822,Weight =54,Phone=092135463,DateOfBirth=DateTime.Parse("2017-09-01")},
                        new Student{StudentName="Arturo",Height=322,Weight =36,Phone=0943987122,DateOfBirth=DateTime.Parse("2018-09-01")},
                        new Student{StudentName="Gytis",Height=432,Weight =233,Phone=0943987122,DateOfBirth=DateTime.Parse("2017-09-01")},
                        new Student{StudentName="Yan",Height=652,Weight =431,Phone=0986788222,DateOfBirth=DateTime.Parse("2017-09-01")},
                        new Student{StudentName="Peggy",Height=1732,Weight =213,Phone=0933112222,DateOfBirth=DateTime.Parse("2016-09-01")},
                        new Student{StudentName="Laura",Height=21,Weight =41,Phone=095566222,DateOfBirth=DateTime.Parse("2018-09-01")},
                        new Student{StudentName="Nino",Height=322,Weight =61,Phone=0956123222,DateOfBirth=DateTime.Parse("2019-09-01")}
                    };
                    context.Students.AddRange(students);
                    context.SaveChanges();
                }

                if (context.Course.Any())
                {
                    return;   // DB has been seeded
                }
                else
                {
                    var courses = new Course[]
                    {
                        new Course{Title="Chemistry",Credits=3},
                        new Course{Title="Microeconomics",Credits=3},
                        new Course{Title="Macroeconomics",Credits=3},
                        new Course{Title="Calculus",Credits=4},
                        new Course{Title="Trigonometry",Credits=4},
                        new Course{Title="Composition",Credits=3},
                        new Course{Title="Literature",Credits=4}
                    };

                    context.Course.AddRange(courses);
                    context.SaveChanges();
                }



                if (context.Enrollment.Any())
                {
                    return;   // DB has been seeded
                }
                else
                {
                    var enrollments = new Enrollment[]
                    {
                        new Enrollment{StudentID=1,CourseID=1,Grade=Grade.A},
                        new Enrollment{StudentID=1,CourseID=2,Grade=Grade.C},
                        new Enrollment{StudentID=1,CourseID=3,Grade=Grade.B},
                        new Enrollment{StudentID=2,CourseID=2,Grade=Grade.B},
                        new Enrollment{StudentID=2,CourseID=1,Grade=Grade.F},
                        new Enrollment{StudentID=2,CourseID=2,Grade=Grade.F},
                        new Enrollment{StudentID=3,CourseID=3},
                        new Enrollment{StudentID=4,CourseID=4},
                        new Enrollment{StudentID=4,CourseID=5,Grade=Grade.F},
                        new Enrollment{StudentID=5,CourseID=2,Grade=Grade.C},
                        new Enrollment{StudentID=6,CourseID=1},
                        new Enrollment{StudentID=7,CourseID=2,Grade=Grade.A},
                    };

                    context.Enrollment.AddRange(enrollments);
                    context.SaveChanges();
                }

            }
        }
    }
}
