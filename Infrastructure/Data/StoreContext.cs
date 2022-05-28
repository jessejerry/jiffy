using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{

    //we need to add entity framework to be able to inherit from DbContext
    public class StoreContext : DbContext
    {

        //constructor that will provide option which is the connection string, 
        //pass those options into the base constructor to the parent class public DbContext(DbContextOptions options)
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        //properties of type Dbset, and the name of the Db set product entity and a 
        //name which is pluralised of the entity
        //Products will be the name of the table that gets created when we generate code  to generate our database
        //this will allow us to access Products and then use 
        //methods defined in DbContext to find an entity with an id or list of all
        //this is what will allow us to query those entities and retreive the data we are looking for on our database


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}