using CarRental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CarRental.Infrastructure.Data.DataBaseConfiguration.EntitiesConfigurations;
public class RentedCarConfiguration : IEntityTypeConfiguration<RentedCar>
{
    /// <summary>
    /// This Class will Configure all the columns needed in the RentedCars Table
    /// </summary>
    public void Configure(EntityTypeBuilder<RentedCar> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(rentedCar => rentedCar.CarId).IsRequired();
        builder.HasIndex(rentedCar => rentedCar.CarId).IsUnique();
    }
}
