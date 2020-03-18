using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using DbContext = System.Data.Entity.DbContext;

namespace ModelDesignFirst.SelfReferenceCodeFirst
{
    public class ProductEntity : DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
        public ProductEntity() : base("name=ProductEntity")
        { }

        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EfCore2020;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Map(m =>
                {
                    m.Properties(p => new { p.SKU, p.Description, p.Price });
                    m.ToTable("Product", "BazaDeDate");
                })
                .Map(m =>
                {
                    m.Properties(p => new { p.SKU, p.ImageURL });
                    m.ToTable("ProductWebInfo", "BazaDeDate");
                });
        }
    }
}
