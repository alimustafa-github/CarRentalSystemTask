using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.DataBaseConfiguration.IdentityConfigurations;

public class ApplicationUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
{
	private string tableName = "ApplicationUserLogins";

	public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
	{
		builder.ToTable(tableName);
	}
}
