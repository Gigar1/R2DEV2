namespace R2DEV2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using R2DEV2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    //blub
    internal sealed class Configuration : DbMigrationsConfiguration<R2DEV2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "R2DEV2.Models.ApplicationDbContext";
            //ContextKey = "R2DEV2.DAL.ApplicationDbContext";
        }

        //protected override void Seed(R2DEV2.DAL.ApplicationDbContext context)
        //{
        //    var students = new List<Student>
        //    {
        //        new Student { FirstName = "Carson",   LastName = "Alexander", EnrollmentDate = DateTime.Parse("2010-09-01") },
        //        new Student { FirstName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2012-09-01") },
        //        new Student { FirstName = "Arturo",   LastName = "Anand", EnrollmentDate = DateTime.Parse("2013-09-01") },
        //        new Student { FirstName = "Gytis",    LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2012-09-01") },
        //        new Student { FirstName = "Yan",      LastName = "Li", EnrollmentDate = DateTime.Parse("2012-09-01") },
        //        new Student { FirstName = "Peggy",    LastName = "Justice", EnrollmentDate = DateTime.Parse("2011-09-01") },
        //        new Student { FirstName = "Laura",    LastName = "Norman", EnrollmentDate = DateTime.Parse("2013-09-01") },
        //        new Student { FirstName = "Nino",     LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-08-11") }
        //    };
        //    students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
        //    context.SaveChanges();

        //    var courses = new List<Course>
        //    {
        //        new Course {CourseId = 1050, CourseName = "Course1",},
        //        new Course {CourseId = 4022, CourseName = "Course2",},
        //        new Course {CourseId = 4041, CourseName = "Course3",},
        //        new Course {CourseId = 1045, CourseName = "Course4",},
        //        new Course {CourseId = 3141, CourseName = "Course5",},
        //        new Course {CourseId = 2021, CourseName = "Course6",},
        //        new Course {CourseId = 2042, CourseName = "Course7",}
        //    };
        //    courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseName, s));
        //    context.SaveChanges();

        //    var enrollments = new List<Enrollment>
        //    {
        //        new Enrollment {
        //            StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
        //            CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
        //            Grade = Grade.A
        //        },
        //         new Enrollment {
        //            StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
        //            CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
        //            Grade = Grade.C
        //         },
        //         new Enrollment {
        //            StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
        //            CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
        //            Grade = Grade.B
        //         },
        //         new Enrollment {
        //             StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
        //            CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
        //            Grade = Grade.B
        //         },
        //         new Enrollment {
        //             StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
        //            CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
        //            Grade = Grade.B
        //         },
        //         new Enrollment {
        //            StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
        //            CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
        //            Grade = Grade.B
        //         },
        //         new Enrollment {
        //            StudentID = students.Single(s => s.LastName == "Anand").StudentID,
        //            CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
        //         },
        //         new Enrollment {
        //            StudentID = students.Single(s => s.LastName == "Anand").StudentID,
        //            CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
        //            Grade = Grade.B
        //         },
        //        new Enrollment {
        //            StudentID = students.Single(s => s.LastName == "Barzdukas").StudentID,
        //            CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
        //            Grade = Grade.B
        //         },
        //         new Enrollment {
        //            StudentID = students.Single(s => s.LastName == "Li").StudentID,
        //            CourseID = courses.Single(c => c.Title == "Composition").CourseID,
        //            Grade = Grade.B
        //         },
        //         new Enrollment {
        //            StudentID = students.Single(s => s.LastName == "Justice").StudentID,
        //            CourseID = courses.Single(c => c.Title == "Literature").CourseID,
        //            Grade = Grade.B
        //         }
        //    };

        //    foreach (Enrollment e in enrollments)
        //    {
        //        var enrollmentInDataBase = context.Enrollments.Where(
        //            s =>
        //                 s.Student.StudentID == e.StudentID &&
        //                 s.Course.CourseID == e.CourseID).SingleOrDefault();
        //        if (enrollmentInDataBase == null)
        //        {
        //            context.Enrollments.Add(e);
        //        }
        //    }
        //    context.SaveChanges();
        //}

        protected override void Seed(R2DEV2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.


            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

            string[] roleNames = new[] { "Teacher", "Student" };
            foreach (string roleName in roleNames)
            {
                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    IdentityRole role = new IdentityRole { Name = roleName };
                    IdentityResult result = roleManager.Create(role);
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join("\n", result.Errors));
                    }
                }
            }

            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);
            string[] emails = new[] { "adam@edu.se", "bart@edu.se", "charlie@edu.se", "dan@edu.se", "erik@gmail.com", "fanny@hotmail.com", "gary@outlook.se", "henry@gmail.com" };
            string[] firstName = new[] { "Adam", "Bart", "Charlie", "Dan", "Erik", "Fanny", "Gary", "Henry" };
            string[] lastName = new[] { "Andersson", "Bertilsson", "Charles", "Dragonborn", "Eriksson", "F", "G", "H" };
            string[] userRole = new[] { "Teacher", "Teacher", "Teacher", "Teacher", "Student", "Student", "Student", "Student" };
            int i = 0;
            foreach (string email in emails)
            {
                if (!context.Users.Any(u => u.UserName == email))
                {
                    ApplicationUser user = new ApplicationUser { UserName = email, Email = email, FirstName = firstName[i], LastName = lastName[i], TimeOfRegistration = DateTime.Now };
                    var result = userManager.Create(user, "password");
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join("\n", result.Errors));
                    }
                }
                i++;

                //if(context.Users.Any(u=>u.UserRole == userRole))
                //{ }
            }





            //////ApplicationUser adminUser = userManager.FindByName("admin@admin.ad");
            //userManager.AddToRole(adminUser.Id, "Admin");

            //adminUser = userManager.FindByName("admin@gymbokning.se");
            //userManager.AddToRole(adminUser.Id, "Admin");

            //foreach (ApplicationUser user in userManager.Users.ToList().Where(u => (u.Email != "admin@admin.ad" || u.Email != "admin@gymbokning.se")))
            //{
            //    userManager.AddToRole(user.Id, "Member");
            //}

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

