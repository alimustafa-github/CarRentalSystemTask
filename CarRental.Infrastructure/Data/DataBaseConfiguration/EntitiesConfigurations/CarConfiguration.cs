using CarRental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.DataBaseConfiguration.EntitiesConfigurations;
/// <summary>
/// This Class will Configure all the columns needed in the Cars Table
/// </summary>
public class CarConfiguration : IEntityTypeConfiguration<Car>
{
	public void Configure(EntityTypeBuilder<Car> builder)
	{
		builder.HasKey(c => c.Id);

		builder.Property(c => c.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

		builder.Property(c => c.SerialNumber)
		.IsRequired()
		.HasMaxLength(50);

		builder.HasIndex(c => c.SerialNumber)
			.IsUnique();

		builder.HasOne(c => c.CarType)
			.WithMany(m => m.Cars)
			.HasForeignKey(d => d.CarTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(c => c.EngineCapacity).IsRequired().HasMaxLength(10);


	}
}
