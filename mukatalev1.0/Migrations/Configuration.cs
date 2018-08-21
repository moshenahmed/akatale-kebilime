namespace mukatalev1._0.Migrations
{
    using mukatalev1._0.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<mukatalev1._0.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(mukatalev1._0.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Posts.AddOrUpdate(
                new Post {
                    Title = "Test Title",
                    Description = "Description",
                    Price = 500,
                    Market = PostViewModel.Markets.Abaita_Ababiri,
                    CreatedAt = DateTime.Now.AddYears(-5)
                }
                );
        }
    }
}
