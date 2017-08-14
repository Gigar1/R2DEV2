using Microsoft.Ajax.Utilities;
using R2DEV2.Models.Classes;

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

            CourseClass[] course = new CourseClass[]
            {
                new CourseClass // Endast för Lärare
                {
                    Name = "Lärare",
                    Description = "Lärare i R2DEV2:s databas.",
                    StartTime = new DateTime(1900, 01, 01),
                    EndTime = new DateTime(2900, 01, 01),
                },

                new CourseClass
                {
                    Name = ".NET Höst",
                    Description = "Hamburger laboris shank, swine dolore in kevin magna pork chop fugiat occaecat pig exercitation andouille. Et pork andouille pancetta veniam burgdoggen sirloin alcatra pariatur duis picanha boudin shoulder. Short loin voluptate incididunt enim deserunt. Dolor non salami pariatur bacon t-bone beef ribs commodo aliqua bresaola culpa veniam leberkas meatball laboris. Porchetta et frankfurter mollit, biltong prosciutto sed proident. Prosciutto cupidatat meatloaf chicken enim rump. Chuck quis dolor et dolore, ground round sint tempor laboris excepteur meatloaf in. Corned beef elit ut filet mignon ea eiusmod tail turducken anim irure flank ball tip. Laboris dolor chuck picanha sint landjaeger velit meatball turducken pancetta elit adipisicing irure short ribs. Irure laborum alcatra kevin mollit hamburger consequat laboris.",
                    StartTime = new DateTime(2015, 09, 11),
                    EndTime = new DateTime(2015, 12, 11),
                },

                new CourseClass
                {
                    Name = "Ny programmeringskurs",
                    Description = "Vi lär dig allt om programmering. Bacon ipsum dolor amet pariatur nulla id pork belly dolore dolor consequat aute tempor jerky brisket. Aliquip cupidatat laborum elit pork belly pastrami non magna pork tail. Leberkas frankfurter alcatra capicola meatball, picanha exercitation. Pig salami elit, minim biltong fatback flank ground round ea pork belly esse. Cupidatat beef cillum shankle tri-tip, picanha tempor.",
                    StartTime = new DateTime(2019, 02, 06),
                    EndTime = new DateTime(2019, 08, 23),
                },

                new CourseClass
                {
                    Name = "Shoppingkurs",
                    Description = "Handla fina saker på stan och ONLINE!",
                    StartTime = new DateTime(2017, 02, 06),
                    EndTime = new DateTime(2017, 09, 11),
                },

                new CourseClass
                {
                    Name = "Fotbollskurs",
                    Description = "Lorem Ipsum Ham hock meatloaf consectetur, dolore sint pork belly turducken ut shankle picanha laborum dolor eu minim. Ut turducken pariatur sausage jowl drumstick dolor. Tongue ut tri-tip landjaeger cillum culpa bacon ea. Laboris tenderloin ad reprehenderit pariatur, quis id frankfurter sirloin boudin ribeye ham hock sausage. Laborum picanha aliquip dolore filet mignon. Eu ex est culpa.",
                    StartTime = new DateTime(2017, 04, 26),
                    EndTime = new DateTime(2017, 10, 14),
                },
            };
            context.CourseClasses.AddOrUpdate(c => c.Name, course);
            context.SaveChanges();

            ModuleClass[] module = new ModuleClass[]
            {
                new ModuleClass
                {
                    Name = "AngularJS",
                    Description = "Beef deserunt anim aute frankfurter lorem doner andouille ham hock laboris meatloaf eu cupim. Minim lorem ball tip porchetta tempor, shoulder ea salami esse turducken nostrud nisi non labore. Landjaeger jerky in ipsum. Velit capicola pancetta spare ribs dolore.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId = course[1].Id,
                },

                new ModuleClass
                {
                    Name = "Databasdesign",
                    Description = "Biltong enim cupidatat labore, turducken tri-tip eu duis shank ipsum t-bone excepteur non quis kevin. Occaecat adipisicing eu qui pancetta burgdoggen consectetur pastrami. Excepteur culpa pork ea frankfurter, t-bone capicola aliqua eiusmod et spare ribs shankle. Tempor sunt jerky, do meatball kevin strip steak doner sausage proident pastrami pork belly. Ex burgdoggen andouille labore, velit ut short ribs sed ham landjaeger cupim biltong cillum. Eu labore sint salami, turkey dolore fatback pariatur proident mollit minim pancetta fugiat chicken sunt. Sirloin salami filet mignon ground round pancetta pig. Beef ribs brisket tri-tip short loin sirloin burgdoggen boudin swine biltong. Brisket beef ribs turducken kielbasa ground round prosciutto cupim rump. Burgdoggen doner shank, t-bone venison jerky rump.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId = course[1].Id,
                },

                new ModuleClass
                {
                    Name = "Bootstrap & CSS",
                    Description = "Lär dig pynta din sida med lite basic bootstrap och css.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId = course[2].Id,
                },

                new ModuleClass
                {
                    Name = "C#",
                    Description = "Lär dig grunderna för C# programmering.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId = course[2].Id,
                },

                new ModuleClass
                {
                    Name = "JavaScript",
                    Description = "Lär dig grunderna för utveckling med JavaScript.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId =  course[2].Id,
                },

                new ModuleClass
                {
                    Name = "PHP",
                    Description = "Lär dig PHP.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId = course[2].Id,
                },

                new ModuleClass
                {
                    Name = "Python",
                    Description = "Lär dig grunderna för Python utveckling.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId = course[2].Id,
                },

                new ModuleClass
                {
                    Name = "Onlineshopping",
                    Description = "Lär dig handla kläder, elektronik och annat kul ONLINE!",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId = course[3].Id,
                },

                new ModuleClass
                {
                    Name = "Butikshopping",
                    Description = "Lär dig gå och strosa runt på stan som en kung.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId = course[3].Id,
                },

                new ModuleClass
                {
                    Name = "Springa",
                    Description = "Spicy jalapeno bacon ipsum dolor amet salami capicola bresaola leberkas pastrami. Landjaeger jowl tail andouille, short loin kevin sirloin swine kielbasa picanha. Sausage spare ribs boudin picanha ham hock pastrami porchetta doner chicken venison. Frankfurter swine porchetta shankle beef ribs.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId = course[4].Id,
                },

                new ModuleClass
                {
                    Name = "Dribbla",
                    Description = "Meatball andouille ground round bresaola shankle swine. Picanha ham hock meatloaf jowl flank chuck. Prosciutto turkey drumstick alcatra shank pork belly. Ham hock doner short loin, ball tip beef hamburger drumstick tenderloin bresaola beef ribs tri-tip flank fatback cow. Cupim venison prosciutto kevin. Porchetta cow strip steak pancetta. Kevin strip steak bacon, sirloin pig short ribs frankfurter hamburger.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId = course[4].Id,
                },

                new ModuleClass
                {
                    Name = "Skjuta",
                    Description = "Sirloin salami filet mignon ground round pancetta pig. Beef ribs brisket tri-tip short loin sirloin burgdoggen boudin swine biltong. Brisket beef ribs turducken kielbasa ground round prosciutto cupim rump. Burgdoggen doner shank, t-bone venison jerky rump.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 11, 14),
                    CourseClassId = course[4].Id,
                },
            };
            context.ModuleClasses.AddOrUpdate(m => m.Name, module);
            context.SaveChanges();

            ActivityClass[] activity = new ActivityClass[]
            {
                new ActivityClass
                {
                    Name = "Introduction",
                    Description = "Sirloin salami filet mignon ground round pancetta pig. Beef ribs brisket tri-tip short loin sirloin burgdoggen boudin swine biltong. Brisket beef ribs turducken kielbasa ground round prosciutto cupim rump. Burgdoggen doner shank, t-bone venison jerky rump. Swine jowl hamburger corned beef short ribs. Beef ribs meatloaf short loin swine brisket hamburger. Tongue bresaola tri-tip, ball tip capicola ground round drumstick jerky corned beef alcatra fatback shoulder rump picanha sirloin. Rump t-bone brisket spare ribs biltong, cupim tenderloin boudin filet mignon tongue. Cow tri-tip frankfurter jowl, ribeye ham hock cupim short loin swine turkey shankle fatback.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[0].Id
                },

                new ActivityClass
                {
                    Name = "AngularJS",
                    Description = "Bacon jerky alcatra biltong ham prosciutto. Biltong pig short ribs fatback kevin rump. Shoulder drumstick ribeye cow, leberkas pork loin meatloaf salami. Cupim alcatra t-bone swine, ham hock corned beef strip steak beef ribs turducken short ribs. Shank sirloin shoulder t-bone, pig pastrami turkey pork ball tip pancetta kevin pork loin alcatra.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[0].Id
                },

                new ActivityClass
                {
                    Name = "Fundamentals",
                    Description = "Hamburger t-bone kevin, biltong pork salami venison tail. Sirloin fatback meatloaf shoulder capicola. Bacon short ribs sausage capicola beef, leberkas tail ball tip. Corned beef cow spare ribs ground round ribeye pork belly brisket porchetta boudin tail chicken tongue hamburger ham hock sausage. Bacon ball tip t-bone turkey rump, meatball short loin fatback shoulder doner prosciutto salami biltong beef tenderloin. Pork beef turkey pig rump pork loin shank drumstick pork chop tail doner.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[0].Id
                },

                new ActivityClass
                {
                    Name = "Best Practices",
                    Description = "Bacon ipsum dolor amet meatball turkey pork chop, capicola jerky kevin prosciutto swine ground round burgdoggen t-bone porchetta beef short ribs rump. Tongue shankle corned beef pork loin short ribs ham hock. Spare ribs bresaola porchetta, rump frankfurter kielbasa filet mignon. Doner pastrami spare ribs pancetta kevin shoulder pork chop turkey bresaola hamburger. Filet mignon pancetta pig bresaola brisket, flank biltong jerky ball tip ribeye landjaeger cow ham prosciutto frankfurter. Pancetta short loin ham hock, turducken doner brisket biltong prosciutto turkey tail. Tenderloin prosciutto kevin rump jerky, ribeye frankfurter tongue filet mignon fatback ham hock chicken turkey tri-tip.",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[0].Id
                },

                new ActivityClass
                {
                    Name = "Database storage",
                    Description = "Det här är en beskrivning till Uppgift 5",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[1].Id
                },

                new ActivityClass
                {
                    Name = "E-learning",
                    Description = "Det här är en beskrivning till Uppgift 1",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[1].Id
                },

                new ActivityClass
                {
                    Name = "Style with CSS5",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[2].Id
                },

                new ActivityClass
                {
                    Name = "Responsive Website",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[2].Id
                },

                new ActivityClass
                {
                    Name = "Style with Bootstrap",
                    Description = "Det här är en beskrivning till Uppgift 4",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[2].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 1",
                    Description = "Det här är en beskrivning till Uppgift 5",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 2",
                    Description = "Det här är en beskrivning till Uppgift 1",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 3",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 4",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 5",
                    Description = "Det här är en beskrivning till Uppgift 4",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 6",
                    Description = "Det här är en beskrivning till Uppgift 5",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 7",
                    Description = "Det här är en beskrivning till Uppgift 1",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 8",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 9",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 10",
                    Description = "Det här är en beskrivning till Uppgift 5",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 11",
                    Description = "Det här är en beskrivning till Uppgift 1",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 12",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 13",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Aktivitet 14",
                    Description = "Det här är en beskrivning till Uppgift 4",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[3].Id
                },

                new ActivityClass
                {
                    Name = "Uppgift 1",
                    Description = "Det här är en beskrivning till Uppgift 5",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[4].Id
                },

                new ActivityClass
                {
                    Name = "Uppgift 2",
                    Description = "Det här är en beskrivning till Uppgift 1",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[4].Id
                },

                new ActivityClass
                {
                    Name = "Uppgift 3",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[4].Id
                },

                new ActivityClass
                {
                    Name = "Uppgift 4",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[4].Id
                },

                new ActivityClass
                {
                    Name = "Uppdrag 1",
                    Description = "Det här är en beskrivning till Uppgift 5",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[5].Id
                },

                new ActivityClass
                {
                    Name = "Uppdrag 2",
                    Description = "Det här är en beskrivning till Uppgift 1",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[5].Id
                },

                new ActivityClass
                {
                    Name = "Uppdrag 3",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[5].Id
                },

                new ActivityClass
                {
                    Name = "Uppdrag 4",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[5].Id
                },

                new ActivityClass
                {
                    Name = "Uppdrag 5",
                    Description = "Det här är en beskrivning till Uppgift 4",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[5].Id
                },

                new ActivityClass
                {
                    Name = "Activity 1",
                    Description = "Det här är en beskrivning till Uppgift 5",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[6].Id
                },

                new ActivityClass
                {
                    Name = "Activity 2",
                    Description = "Det här är en beskrivning till Uppgift 1",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[6].Id
                },

                new ActivityClass
                {
                    Name = "Activity 3",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[6].Id
                },

                new ActivityClass
                {
                    Name = "Onlinepizza",
                    Description = "Det här är en beskrivning till Uppgift 5",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[7].Id
                },

                new ActivityClass
                {
                    Name = "AliExpress",
                    Description = "Det här är en beskrivning till Uppgift 1",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[7].Id
                },

                new ActivityClass
                {
                    Name = "Zalando",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[7].Id
                },

                new ActivityClass
                {
                    Name = "Pizzeria Glada Hudik",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[8].Id
                },

                new ActivityClass
                {
                    Name = "Thai-vagnen",
                    Description = "Det här är en beskrivning till Uppgift 4",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[8].Id
                },

                new ActivityClass
                {
                    Name = "Hemköp",
                    Description = "Det här är en beskrivning till Uppgift 5",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[8].Id
                },

                new ActivityClass
                {
                    Name = "Konditionsträning",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[9].Id
                },

                new ActivityClass
                {
                    Name = "Tunnla Zlatan",
                    Description = "Det här är en beskrivning till Uppgift 4",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[10].Id
                },

                new ActivityClass
                {
                    Name = "Dribbla förbi hela Malmö FF",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[10].Id
                },

                new ActivityClass
                {
                    Name = "Hörnor",
                    Description = "Det här är en beskrivning till Uppgift 4",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[11].Id
                },

                new ActivityClass
                {
                    Name = "Frisparkar",
                    Description = "Det här är en beskrivning till Uppgift 3",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[11].Id
                },

                new ActivityClass
                {
                    Name = "Straffar",
                    Description = "Det här är en beskrivning till Uppgift 4",
                    StartTime = new DateTime(2015, 10, 14),
                    EndTime = new DateTime(2015, 10, 14),
                    ModuleClassId = module[11].Id
                }
            };
            context.ActivityClasses.AddOrUpdate(a => a.Name, activity);
            context.SaveChanges();

            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);
            string[] emails = new[] { "teacher@lexicon.se", "john@lexicon.se", "dimitris@lexicon.se", "bob@lexicon.se", "hans@lexicon.se", "olle@lexicon.se", "marcus@lexicon.se", "johan@lexicon.se", "gigar@lexicon.se", "victor@lexicon.se", "mats@lexicon.se", "anton@lexicon.se", "andres@lexicon.se", "henrik@lexicon.se", "thomas@lexicon.se", "zlatan@lexicon.se", "neymar@lexicon.se", "steven@lexicon.se", "messi@lexicon", "ronaldo@lexicon.se" };
            string[] firstName = new[] { "Teacher", "John", "Dimitris", "Bob", "Hans", "Olle", "Marcus", "Johan", "Gigar", "Victor", "Mats", "Anton", "Andres", "Henrik", "Thomas", "Zlatan", "Neymar", "Steven", "Leo", "Cristiano" };
            string[] lastName = new[] { "Lexicon", "Hellman", "Björlingh", "Bobsson", "Andersen", "Oren", "Broman", "Bengter", "Khalil", "Berglund", "Danhard", "Olsson", "Pontio", "Forslin", "Myrsten", "Ibrahimovic", "Jr", "Gerrard", "Messi", "Ronaldo" };

            int i = 0;
            foreach (string email in emails)
            {
                if (!context.Users.Any(u => u.UserName == email))
                {
                    if (i < 3)
                    {
                        ApplicationUser user = new ApplicationUser { UserName = email, Email = email, FirstName = firstName[i], LastName = lastName[i], TimeOfRegistration = DateTime.Now, CourseClassId = course[0].Id };
                        var result = userManager.Create(user, "password");
                        if (!result.Succeeded)
                        {
                            throw new Exception(string.Join("\n", result.Errors));
                        }
                    }

                    else if (i < 6)
                    {
                        ApplicationUser user = new ApplicationUser { UserName = email, Email = email, FirstName = firstName[i], LastName = lastName[i], TimeOfRegistration = DateTime.Now, CourseClassId = course[2].Id };
                        var result = userManager.Create(user, "password");
                        if (!result.Succeeded)
                        {
                            throw new Exception(string.Join("\n", result.Errors));
                        }
                    }

                    else if (i < 15)
                    {
                        ApplicationUser user = new ApplicationUser { UserName = email, Email = email, FirstName = firstName[i], LastName = lastName[i], TimeOfRegistration = DateTime.Now, CourseClassId = course[1].Id };
                        var result = userManager.Create(user, "password");
                        if (!result.Succeeded)
                        {
                            throw new Exception(string.Join("\n", result.Errors));
                        }
                    }

                    else
                    {
                        ApplicationUser user = new ApplicationUser { UserName = email, Email = email, FirstName = firstName[i], LastName = lastName[i], TimeOfRegistration = DateTime.Now, CourseClassId = course[4].Id };
                        var result = userManager.Create(user, "password");
                        if (!result.Succeeded)
                        {
                            throw new Exception(string.Join("\n", result.Errors));
                        }
                    }
                }
                i++;
            }

            ApplicationUser Teacher = userManager.FindByName("john@lexicon.se");
            userManager.AddToRole(Teacher.Id, "Teacher");

            Teacher = userManager.FindByName("teacher@lexicon.se");
            userManager.AddToRole(Teacher.Id, "Teacher");

            Teacher = userManager.FindByName("dimitris@lexicon.se");
            userManager.AddToRole(Teacher.Id, "Teacher");

            foreach (ApplicationUser user in userManager.Users.ToList().Where(u => (u.Email != "teacher@lexicon.se" && u.Email != "john@lexicon.se" && u.Email != "dimitris@lexicon.se")))
            {
                userManager.AddToRole(user.Id, "Student");
            }

            context.SaveChanges();
        }
    }
};
