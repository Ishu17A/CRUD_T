namespace Aman_MVCTest_.Migrations
{
    using Aman_MVCTest_.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Aman_MVCTest_.Models.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Aman_MVCTest_.Models.BlogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Users.Add(new User { UserId=Guid.NewGuid(),UserName = "Admin", Password = "admin123", Role = "Admin" });
            context.Users.Add(new User { UserId=Guid.NewGuid(),UserName = "Aman", Password = "aman", Role = "User" });

          

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
