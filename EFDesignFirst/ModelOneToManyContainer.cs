using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EFDesignFirst
{
    public partial class ModelOneToManyContainer : DbContext
    {
        public ModelOneToManyContainer()
            : base("name=ModelOneToManyContainer")
        { }

        protected override void OnModelCreating(
            DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

    }
}