using Microsoft.EntityFrameworkCore;
using EFAutoSalon;

namespace ASPNETAutoSalon

{
    public class ApplContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public ApplContext(DbContextOptions<ApplContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>().HasData(
                new Buyer { Id = 1, Name = "Buyer1", Surname = "Bumich", Gender = "M"},
                new Buyer { Id = 2, Name = "Buyer2", Surname = "Antusov", Gender = "M"},
                new Buyer { Id = 3, Name = "Buyer3", Surname = "Dudnikova", Gender = "F"}
                );

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Name = "McLaren P1", YearOfRelease = 2022},
                new Car { Id = 2, Name = "Lambargini Huracan", YearOfRelease = 2023},
                new Car { Id = 3, Name = "BMW M5", YearOfRelease = 2023},
                new Car { Id = 4, Name = "Buggaty Veyron", YearOfRelease = 2021}
                );
        }
    }
}
