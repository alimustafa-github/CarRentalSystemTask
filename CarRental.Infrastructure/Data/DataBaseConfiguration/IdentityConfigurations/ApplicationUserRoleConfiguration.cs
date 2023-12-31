﻿namespace CarRental.Infrastructure.Data.DataBaseConfiguration.IdentityConfigurations;

public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
	private string tableName = "ApplicationUserRoles";

	public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
	{
		builder.ToTable(tableName);
	}
}
