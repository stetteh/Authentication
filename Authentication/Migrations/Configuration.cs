using Authentication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Authentication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Authentication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Authentication.Models.ApplicationDbContext context)
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

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!context.Roles.Any())
            {
                roleManager.Create(new IdentityRole("Admin"));
                roleManager.Create(new IdentityRole("Developer"));
                roleManager.Create(new IdentityRole("Secretary"));
            }

            if (!context.Users.Any(x => x.UserName == "lsat@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    FirstName = "Luke",
                    LastName = "Satsey",
                    DateOfBirth = DateTime.Parse("04/04/2000"),
                    NickName = "lfunny",
                    Email = "lsat@gmail.com",
                    UserName = "lsat@gmail.com",
                };
                userManager.Create(user, "MyP@ssw0rd!");
                userManager.AddToRole(user.Id, "Admin");

                var user1 = new ApplicationUser
                {
                    FirstName = "Ann",
                    LastName = "Marie",
                    DateOfBirth = DateTime.Parse("01/01/1994"),
                    NickName = "Magarita",
                    Email = "ama@gmail.com",
                    UserName = "ama@gmail.com",
                };
                userManager.Create(user, "OmyGoodness3$");
                userManager.AddToRole(user.Id, "Developer");


                var user2 = new ApplicationUser
                {
                    FirstName = "Jerry",
                    LastName = "Brown",
                    DateOfBirth = DateTime.Parse("12/01/1942"),
                    NickName = "OldDog",
                    Email = "odo@gmail.com",
                    UserName = "odo@gmail.com",
                };
                userManager.Create(user, "comeHome56*");
                userManager.AddToRole(user.Id, "Admin");

                var user4 = new ApplicationUser
                {
                    FirstName = "Izzy",
                    LastName = "Smith",
                    DateOfBirth = DateTime.Parse("10/10/1999"),
                    NickName = "loveme",
                    Email = "izz@gmail.com",
                    UserName = "izz@gmail.com",
                };
                userManager.Create(user, "passwordT90#*");
                userManager.AddToRole(user.Id, "Secretary");

            }
        }
    }
}
