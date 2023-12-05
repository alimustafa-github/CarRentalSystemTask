namespace CarRental.Infrastructure.Data.DataBaseConfiguration.IdentityConfigurations;
public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
	private string tableName = "ApplicationUsers";
	public void Configure(EntityTypeBuilder<ApplicationUser> builder)
	{
		builder.ToTable(tableName);

		builder.Property(u => u.FirstName).IsRequired().HasMaxLength(12);

		builder.Property(u => u.LastName).IsRequired(false).HasMaxLength(12);

		builder.Property(u => u.DateOfBirth).IsRequired(false);

		builder.Property(u => u.CurrentAddress).IsRequired(false);
	}
}
