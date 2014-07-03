namespace MvcApplication3.Migrations
{
    using MvcApplication3.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcApplication3.Models.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcApplication3.Models.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.People.AddOrUpdate(
              p => p.Username,
              new Person { Username = "Andre", Password = "1" },
              new Person { Username = "Brice", Password = "2" },
              new Person { Username = "Rowan", Password = "3" }
            );

            context.Departments.AddOrUpdate(
                d => d.DepartmentName,
                new Department { DepartmentName = "Accounting" },
                new Department { DepartmentName = "Finance" },
                new Department { DepartmentName = "SE" }
            );
        }
    }
}
