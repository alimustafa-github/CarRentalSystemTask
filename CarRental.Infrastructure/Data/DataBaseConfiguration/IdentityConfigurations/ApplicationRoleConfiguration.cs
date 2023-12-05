namespace CarRental.Infrastructure.Data.DataBaseConfiguration.IdentityConfigurations;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
	private string tableName = "ApplicationRoles";

	public void Configure(EntityTypeBuilder<IdentityRole> builder)
	{
		builder.ToTable(tableName);
		builder.Property(role => role.Name).IsRequired(true);
	}
}
