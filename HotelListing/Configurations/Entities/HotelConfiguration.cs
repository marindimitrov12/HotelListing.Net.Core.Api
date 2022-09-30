using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                 new Hotel
                 {
                     Id = 1,
                     Name = "Maxxi",
                     Address = "Agril",
                     CountryId = 1,
                     Rating = 4.5,
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
    }
}
