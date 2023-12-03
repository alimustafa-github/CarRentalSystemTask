using CarRental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.DataBaseConfiguration.EntitiesConfigurations;
public class CarTypeConfiguration : IEntityTypeConfiguration<CarType>
{
	public void Configure(EntityTypeBuilder<CarType> builder)
	{
		builder.HasKey(c => c.Id);

		builder.Property(c => c.Title).IsRequired(true).HasMaxLength(20).IsUnicode(false);
		builder.Property(c => c.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

	}
}
