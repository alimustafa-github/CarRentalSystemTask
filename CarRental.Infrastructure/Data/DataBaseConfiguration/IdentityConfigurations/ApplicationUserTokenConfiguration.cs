using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.DataBaseConfiguration.IdentityConfigurations;

public class ApplicationUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
{
	private string tableName = "ApplicationUserTokens";

	public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
	{
		builder.ToTable(tableName);
	}
}
