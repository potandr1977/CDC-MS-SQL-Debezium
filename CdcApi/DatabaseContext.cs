using CdcApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CdcApi
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions):base(dbContextOptions) 
        {
            try 
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dbCreator != null)
                {
                    if (!dbCreator.CanConnect())
                    {
                        dbCreator.Create();
                    }

                    if (!dbCreator.HasTables())
                    {
                        dbCreator.CreateTables();
                    }
                }

            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().HasData(
                new Contract[]
                {
                    new Contract { Id =1, Name="GazProtTechnology"},
                    new Contract { Id =2, Name="ElfPetrolium"},
                });
            //modelBuilder.Entity<LifeEvent>().HasOne(le => le.Person).WithMany(p => p.LifeEvents).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Contract> Contracts { get; set; }
    }
}
