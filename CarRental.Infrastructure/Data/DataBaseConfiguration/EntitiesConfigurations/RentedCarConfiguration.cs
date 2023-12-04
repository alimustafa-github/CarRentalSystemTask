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
		builder.HasKey(r => r.Id);
		builder.Property(r => r.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

		builder.Property(r => r.DriverId).IsRequired(false);
		builder.HasIndex(d => d.DriverId).IsUnique();

		builder.Property(r => r.CarId).IsRequired();
		builder.HasIndex(r => r.CarId).IsUnique();

		builder.Property(r => r.CustomerId).IsRequired();
		builder.HasOne(r => r.Customer)
			   .WithMany(c => c.RentedCars)
			   .HasForeignKey(r => r.CustomerId)
			   .OnDelete(DeleteBehavior.Cascade);

		builder.Property(r=>r.ReservationStartDate).IsRequired().HasDefaultValue(DateTime.Now);

		builder.Property(r => r.ReservationEndDate).IsRequired().HasDefaultValue(DateTime.Now.AddMonths(6));

	}
}
