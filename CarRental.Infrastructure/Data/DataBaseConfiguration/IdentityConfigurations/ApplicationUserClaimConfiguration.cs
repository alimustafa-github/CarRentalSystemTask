namespace CarRental.Infrastructure.Data.DataBaseConfiguration.IdentityConfigurations;

public class ApplicationUserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
{
	private string tableName = "ApplicationUserClaims";

	public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
	{
		builder.ToTable(tableName);
	}
}
