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
		builder.HasOne(r => r.Driver)
			   .WithOne(d => d.RentedCar)
			   .HasForeignKey<RentedCar>(r => r.DriverId)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.Property(r => r.CarId).IsRequired();
		builder.HasIndex(r => r.CarId).IsUnique();
		builder.Property(r => r.DriverId).IsRequired(false);
		builder.HasIndex(d => d.DriverId).IsUnique();
		builder.HasOne(r => r.Car)
			   .WithOne(c => c.RentalDetails)
			   .HasForeignKey<RentedCar>(r => r.CarId)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.Property(r => r.CustomerId).IsRequired();
		builder.HasOne(r => r.Customer)
			   .WithMany(c => c.RentedCars)
			   .HasForeignKey(r => r.CustomerId)
			   .OnDelete(DeleteBehavior.Cascade);

		builder.Property(r => r.ReservationStartDate).IsRequired();

		builder.Property(r => r.ReservationEndDate).IsRequired();

	}
}
