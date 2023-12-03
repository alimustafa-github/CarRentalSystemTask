using CarRental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Data.DataBaseConfiguration.EntitiesConfigurations;
/// <summary>
/// This Class will Configure all the columns needed in the Drivers Table
/// </summary>
public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
	private string tableName = "Drivers";

	public void Configure(EntityTypeBuilder<Driver> builder)
	{
		builder.ToTable(tableName);

		builder.HasKey(d => d.Id);
		builder.Property(d => d.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

		builder.HasOne(d => d.User)
			.WithOne(u => u.Driver)
			.HasForeignKey<Driver>(d => d.UserId)
			.OnDelete(DeleteBehavior.Cascade);
		builder.HasIndex(d => d.UserId).IsUnique();

		builder.Property(d => d.TotalRentalCount).IsRequired().HasDefaultValue(0);

		builder.Property(d => d.JoinDate).IsRequired().HasDefaultValue(DateTime.Now);

		builder.Property(d => d.ContractEndDate).IsRequired().HasDefaultValue(DateTime.Now.AddMonths(6));

		builder.Property(d => d.LicenceNumber).IsRequired().IsUnicode(false).HasMaxLength(12);
		builder.HasIndex(d => d.LicenceNumber).IsUnique();

		builder.Property(d => d.LicenseExpirationDate).IsRequired();

		builder.Property(d => d.ContractNumber).IsRequired();
		builder.HasIndex(d => d.ContractNumber).IsUnique();

		builder.Property(d => d.IsBusy).IsRequired().HasDefaultValue(false);

	}
}
