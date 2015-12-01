using System.Data.Entity;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, Configuration>());
        //    //AutomaticMigrationsEnabled = true;
        //    //base.OnModelCreating(modelBuilder);
        //}
    }
}
