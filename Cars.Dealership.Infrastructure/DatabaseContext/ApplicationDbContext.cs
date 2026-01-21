using Cars.Dealership.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.Dealership.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Image> Images { get; set; }



        /// /////////////////////////////////////////////
        // remind your self tomorrow what this code does
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            Console.WriteLine("APP DB CONTEXT CREATED");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Image>().ToTable("Images");

            base.OnModelCreating(modelBuilder);
        }

        // all the way to here

    }
}
