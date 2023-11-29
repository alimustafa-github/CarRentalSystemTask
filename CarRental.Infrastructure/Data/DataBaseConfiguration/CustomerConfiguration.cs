using CarRental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.DataBaseConfiguration;
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		builder.HasKey(d => d.Id);

		builder.Property(d => d.FirstName).IsRequired().HasMaxLength(20);
		builder.Property(d => d.LastName).IsRequired().HasMaxLength(20);
	}
}
