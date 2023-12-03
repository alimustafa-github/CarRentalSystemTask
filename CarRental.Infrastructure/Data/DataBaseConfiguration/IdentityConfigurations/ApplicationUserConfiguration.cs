using CarRental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Data.DataBaseConfiguration.IdentityConfigurations;
public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
	private string tableName = "ApplicationUsers";
	public void Configure(EntityTypeBuilder<ApplicationUser> builder)
	{
		builder.ToTable(tableName);

		builder.Property(u => u.FirstName).IsRequired().HasMaxLength(12);
		builder.Property(u => u.LastName).IsRequired().HasMaxLength(12);


	}
}
