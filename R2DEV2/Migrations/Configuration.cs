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

        #region WIP Seed
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
        #endregion

        protected override void Seed(R2DEV2.Models.ApplicationDbContext context)
        {
            #region Example
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
            #endregion

            #region Old Seed
            //  This method will be called after migrating to the latest version.
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

            #region RoleNames
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
            #endregion
            #region Users
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
            #endregion
            #endregion

            #region New Seed
            //Seedar in Kurser
            Course[] course = new Course[]
            {
                new Course { CourseId = 1, CourseName = "Kurs1" },
                new Course { CourseId = 2, CourseName = "Kurs2" },
                new Course { CourseId = 3, CourseName = "Kurs3" },
                new Course { CourseId = 4, CourseName = "Kurs4" },
                new Course { CourseId = 5, CourseName = "Kurs5" },
                new Course { CourseId = 6, CourseName = "Kurs6" }
            };
            //foreach (Course c in course)
            //{
            //    context.Courses.Add(c);
            //}

            //Seedar in Moduler
            Module[] module = new Module[]
            {
                new Module { ModuleId = 1, ModuleName = "Modul1", ModuleDescription = "Modul1 Description", },
                new Module { ModuleId = 2, ModuleName = "Modul2", ModuleDescription = "Modul2 Description", },
                new Module { ModuleId = 3, ModuleName = "Modul3", ModuleDescription = "Modul3 Description", },
                new Module { ModuleId = 4, ModuleName = "Modul4", ModuleDescription = "Modul4 Description", },
                new Module { ModuleId = 5, ModuleName = "Modul5", ModuleDescription = "Modul5 Description", },
                new Module { ModuleId = 6, ModuleName = "Modul6", ModuleDescription = "Modul6 Description", }
            };
            //foreach (Module m in module)
            //{
            //context.Modules.Add(m);
            //}

            //Seedar in Aktiviteter
            Activity[] activity = new Activity[]
            {
                new Activity { ActivityId = 1, ActivityName = "Aktivitet1" },
                new Activity { ActivityId = 2, ActivityName = "Aktivitet2" },
                new Activity { ActivityId = 3, ActivityName = "Aktivitet3" },
                new Activity { ActivityId = 4, ActivityName = "Aktivitet4" },
                new Activity { ActivityId = 5, ActivityName = "Aktivitet5" },
                new Activity { ActivityId = 6, ActivityName = "Aktivitet6" }
            };
            //foreach (Activity a in activity)
            //{
            //context.Activities.Add(a);
            //}
            //Någonting är fel, kan inte seedas in för tillfället...

            #endregion
        }
    }
}

