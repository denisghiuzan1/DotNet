using Microsoft.EntityFrameworkCore;

namespace ModelDesignFirst.SelfReferenceCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SelfReferenceModel : DbContext
    {
        // Your context has been configured to use a 'SelfReferenceModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ModelDesignFirst.SelfReferenceCodeFirst.SelfReferenceModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SelfReferenceModel' 
        // connection string in the application configuration file.
        public SelfReferenceModel()
            : base("name=SelfReferenceModel")
        {
        }

        public virtual DbSet<SelfReference> SelfReferences { get; set; }

        //protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EfCore2020;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //    //ChangeTracker.LazyLoadingEnabled = false;
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SelfReference>()
                .HasMany(m => m.References)
                .WithOptional(m => m.ParentSelfReference)
                .HasForeignKey(m=>m.ParentSelfReferenceId);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}