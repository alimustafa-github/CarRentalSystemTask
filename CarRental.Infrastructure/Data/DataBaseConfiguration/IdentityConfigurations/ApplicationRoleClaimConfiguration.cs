﻿namespace CarRental.Infrastructure.Data.DataBaseConfiguration.IdentityConfigurations;

public class ApplicationRoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
{
	private string tableName = "ApplicationRoleClaims";

	public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
	{
		builder.ToTable(tableName);
	}
}
