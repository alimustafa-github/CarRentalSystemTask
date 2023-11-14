using CarRental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Data.DataBaseConfiguration;
/// <summary>
/// This Class will Configure all the columns needed in the Drivers Table
/// </summary>
public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
	public void Configure(EntityTypeBuilder<Driver> builder)
	{
		builder.HasKey(d => d.Id);

		builder.Property(d => d.FirstName).IsRequired().HasMaxLength(20);
		builder.Property(d => d.LastName).IsRequired().HasMaxLength(20);

		builder.Property(d=>d.IsBusy).IsRequired().HasDefaultValue(false);
	}
}
