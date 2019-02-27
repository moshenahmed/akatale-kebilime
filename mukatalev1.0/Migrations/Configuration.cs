namespace mukatalev1._0.Migrations
{
    using Microsoft.AspNet.Identity;
    using mukatalev1._0.Models;
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<mukatalev1._0.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(mukatalev1._0.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //context.Posts.AddOrUpdate(
            //    new Post
            //    {
            //        Title = "Test Title",
            //        Description = "Description",
            //        Price = 500,
            //        Location = "Kampala uganda",
            //        CreatedAt = DateTime.Now.AddYears(-5)
            //    }
            //    );

            //var store = new RoleStore<IdentityRole>(context);
            //var manager = new RoleManager<IdentityRole>(store);
            //var role = new IdentityRole { Name = "Admin" };
            //var role2 = new IdentityRole { Name = "User" };

            //manager.Create(role);
            //manager.Create(role2);
            //var store2 = new UserStore<ApplicationUser>(context);
            //var manager2 = new UserManager<ApplicationUser>(store2);
            //var user = new ApplicationUser
            //{
            //    UserName = "Admin",
            //    Status = true,
            //};
            //manager2.Create(user, "Test1!");
            //manager2.AddToRole(user.Id, "Admin");
        }
    }
}
