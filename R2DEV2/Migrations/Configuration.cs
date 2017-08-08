namespace R2DEV2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using R2DEV2.Models;
    using R2DEV2.Models.Classes;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<R2DEV2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(R2DEV2.Models.ApplicationDbContext context)
        {
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

            CourseClass[] course = new CourseClass[] {
                new CourseClass
                {
                    Name = ".NET Höst",
                    Description = "En superrolig kurs som passar alla mellan 10 - 100 år. I kursen ingår moduler som 'Databasdesign', 'AngularJS'.",
                    StartTime = new DateTime(2015, 09, 11),
                    EndTime = new DateTime(2015, 12, 11),
                    Modules = new List<ModuleClass>
                    {
                        new ModuleClass
                        {
                            Name = "Bootstrap & CSS",
                            Description = "Lär dig pynta din sida med lite basic bootstrap och css.",
                            StartTime = new DateTime(2015, 10, 14),
                            EndTime = new DateTime(2015, 11, 14),
                            Activities = new List<ActivityClass>
                            {
                                new ActivityClass
                                {
                                    Name = "Uppgift 1",
                                    Description = "Det här är en beskrivning till Uppgift 1",
                                    StartTime = new DateTime(2015, 10, 14),
                                    EndTime = new DateTime(2015, 10, 14)
                                },

                                new ActivityClass
                                {
                                    Name = "Uppgift 2",
                                    Description = "Det här är en beskrivning till Uppgift 3",
                                    StartTime = new DateTime(2015, 10, 14),
                                    EndTime = new DateTime(2015, 10, 14)
                                },

                                new ActivityClass
                                {
                                    Name = "Uppgift 3",
                                    Description = "Det här är en beskrivning till Uppgift 3",
                                    StartTime = new DateTime(2015, 10, 14),
                                    EndTime = new DateTime(2015, 10, 14)
                                },

                                new ActivityClass
                                {
                                    Name = "Uppgift 4",
                                    Description = "Det här är en beskrivning till Uppgift 4",
                                    StartTime = new DateTime(2015, 10, 14),
                                    EndTime = new DateTime(2015, 10, 14)
                                },

                                new ActivityClass
                                {
                                    Name = "Uppgift 5",
                                    Description = "Det här är en beskrivning till Uppgift 5",
                                    StartTime = new DateTime(2015, 10, 14),
                                    EndTime = new DateTime(2015, 10, 14)
                                }
                            },
                        },

                        new ModuleClass
                        {
                            Name = "AngularJS",
                            Description = "Grunderna för AngularJS.",
                            StartTime = new DateTime(2015, 10, 14),
                            EndTime = new DateTime(2015, 11, 14),
                            Activities = new List<ActivityClass>()
                        },

                        new ModuleClass
                        {
                            Name = "Databasdesign",
                            Description = "Det är svårare än vad ni tror.",
                            StartTime = new DateTime(2015, 10, 14),
                            EndTime = new DateTime(2015, 11, 14),
                            Activities = new List<ActivityClass>()
                        }
                    },
                    AttendingStudents = new List<ApplicationUser>()
                },


                 new CourseClass
                {
                    Name = "Ny programmeringskurs",
                    Description = "Vi lär dig allt om programmering.",
                    StartTime = new DateTime(2019, 02, 06),
                    EndTime = new DateTime(2019, 08, 23),
                    Modules = new List<ModuleClass>
                    {
                        new ModuleClass
                        {
                            Name = "C#",
                            Description = "Lär dig grunderna för C# programmering.",
                            StartTime = new DateTime(2015, 10, 14),
                            EndTime = new DateTime(2015, 11, 14),
                            Activities = new List<ActivityClass>()
                        },

                        new ModuleClass
                        {
                            Name = "JavaScript",
                            Description = "Lär dig grunderna för utveckling med JavaScript.",
                            StartTime = new DateTime(2015, 10, 14),
                            EndTime = new DateTime(2015, 11, 14),
                            Activities = new List<ActivityClass>()
                        },

                        new ModuleClass
                        {
                            Name = "PHP",
                            Description = "Lär dig PHP.",
                            StartTime = new DateTime(2015, 10, 14),
                            EndTime = new DateTime(2015, 11, 14),
                            Activities = new List<ActivityClass>()
                        },

                        new ModuleClass
                        {
                            Name = "Python",
                            Description = "Lär dig grunderna för Python utveckling.",
                            StartTime = new DateTime(2015, 10, 14),
                            EndTime = new DateTime(2015, 11, 14),
                            Activities = new List<ActivityClass>()
                        }
                    },
                    AttendingStudents = new List<ApplicationUser>()
                },


                 new CourseClass
                {
                    Name = "Shoppingkurs distans",
                    Description = "Handla fina saker online.",
                    StartTime = new DateTime(2017, 02, 06),
                    EndTime = new DateTime(2017, 09, 11),
                    Modules = new List<ModuleClass>
                    {
                        new ModuleClass
                        {
                            Name = "Onlineshopping",
                            Description = "Lär dig handla kläder, elektronik och annat kul ONLINE!",
                            StartTime = new DateTime(2015, 10, 14),
                            EndTime = new DateTime(2015, 11, 14),
                            Activities = new List<ActivityClass>()
                        },

                        new ModuleClass
                        {
                            Name = "Butikshopping",
                            Description = "Lär dig gå och strosa runt på stan som en kung.",
                            StartTime = new DateTime(2015, 10, 14),
                            EndTime = new DateTime(2015, 11, 14),
                            Activities = new List<ActivityClass>()
                        }
                    },
                    AttendingStudents = new List<ApplicationUser>()
                }
            };


            foreach (CourseClass g in course)
            {
                context.CourseClasses.Add(g);
            }
            context.SaveChanges();

            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);
            string[] emails = new[] { "john@lexicon.se", "teacher@lexicon.se", "bob@lexicon.se", "hans@lexicon.se", "olle@lexicon.se", "marcus@lexicon.se", "johan@lexicon.se", "gigar@lexicon.se", "elev@lexicon.se" };
            string[] firstName = new[] { "John", "Teacher", "Bob", "Hans", "Olle", "Marcus", "Johan", "Gigar", "Elev" };
            string[] lastName = new[] { "Hellman", "Lexicon", "Bobsson", "Andersen", "Oren", "Broman", "Bengter", "Khalil", "Lexicon" };
            int[] courseClassId = new[] { 1,2,3,1,2,3,1,2,3 };

            int i = 0;
            foreach (string email in emails)
            {
                if (!context.Users.Any(u => u.UserName == email))
                {
                    ApplicationUser user = new ApplicationUser { UserName = email, Email = email, FirstName = firstName[i], LastName = lastName[i], TimeOfRegistration = DateTime.Now, CourseClassId = courseClassId[i]};
                    var result = userManager.Create(user, "password");
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join("\n", result.Errors));
                    }
                }
                i++;
            }

            ApplicationUser Teacher = userManager.FindByName("john@lexicon.se");
            userManager.AddToRole(Teacher.Id, "Teacher");

            Teacher = userManager.FindByName("teacher@lexicon.se");
            userManager.AddToRole(Teacher.Id, "Teacher");

            foreach (ApplicationUser user in userManager.Users.ToList().Where(u => (u.Email != "admin@admin.ad" && u.Email != "admin@Gymbokning.se")))
            {
                userManager.AddToRole(user.Id, "Student");
            }

            context.SaveChanges();
        }
    }
}
