using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst.SelfReferenceCodeFirst
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeContext()
            : base("name=SelfReferenceModel")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Map<FullTimeEmployee>(m => m.Requires("EmployeeType")
                    .HasValue(1))
                .Map<HourlyEmployee>(m => m.Requires("EmployeeType")
                    .HasValue(2));
        }

    }
}
