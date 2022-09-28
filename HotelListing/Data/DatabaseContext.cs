using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id=1,
                    Name="Jamaica",
                    ShortName="JM"
                },
                 new Country
                 {
                     Id = 2,
                     Name = "Bahamas",
                     ShortName = "BS"
                 },
                 new Country
                 {
                     Id = 3,
                     Name = "Cayman Island",
                     ShortName = "CI"
                 });
            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Maxxi",
                    Address = "Agril",
                    CountryId=1,
                    Rating=4.5,
                },
               new Hotel
               {
                   Id = 2,
                   Name = "Sandals Resort and Spa",
                   Address = "Negril",
                   CountryId = 2,
                   Rating = 1.5,
               },
                new Hotel
                {
                    Id = 3,
                    Name = "Grand Palldium",
                    Address = "Negril",
                    CountryId = 3,
                    Rating = 5.5,
                });
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
