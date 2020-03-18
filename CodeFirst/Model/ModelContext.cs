using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Model
{
    internal class ModelContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany<Order>(o => o.Orders)
                .WithOne(c => c.Client);

            modelBuilder.Entity<OrderDetails>()
                .HasOne<Order>(od => od.Order)
                .WithMany(o => o.OrderDetails);
            modelBuilder.Entity<Product>()
                .HasMany<OrderDetails>(p => p.OrderDetails)
                .WithOne(od => od.Product);
        }
    }
}
