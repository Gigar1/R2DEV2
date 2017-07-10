namespace R2DEV2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using R2DEV2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<R2DEV2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "R2DEV2.Models.ApplicationDbContext";
        }

        protected override void Seed(R2DEV2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

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
            }
            //////ApplicationUser adminUser = userManager.FindByName("admin@admin.ad");
            //userManager.AddToRole(adminUser.Id, "Admin");

            //adminUser = userManager.FindByName("admin@gymbokning.se");
            //userManager.AddToRole(adminUser.Id, "Admin");

            //foreach (ApplicationUser user in userManager.Users.ToList().Where(u => (u.Email != "admin@admin.ad" || u.Email != "admin@gymbokning.se")))
            //{
            //    userManager.AddToRole(user.Id, "Member");
            //}
        }
    }
}
