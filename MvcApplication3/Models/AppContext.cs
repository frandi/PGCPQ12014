using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.People)
                .WithOptional(p => p.Department)
                .HasForeignKey(p => p.DepartmentId);
        }
    }
}