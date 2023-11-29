using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.DataBaseConfiguration.IdentityConfigurations;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
	private string tableName = "ApplicationRoles";

	public void Configure(EntityTypeBuilder<IdentityRole> builder)
	{
		builder.ToTable(tableName);
	}
}
