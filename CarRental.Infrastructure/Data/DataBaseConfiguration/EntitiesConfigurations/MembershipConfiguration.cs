namespace CarRental.Infrastructure.Data.DataBaseConfiguration.EntitiesConfigurations;
public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
{
	public void Configure(EntityTypeBuilder<Membership> builder)
	{
		builder.HasKey(m => m.Id);
		builder.Property(m => m.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

		builder.Property(m => m.Level).IsRequired(true).IsUnicode(false).HasMaxLength(12);
		builder.HasIndex(m => m.Level).IsUnique();
	}
}
