namespace CarRental.Infrastructure.Data.DataBaseConfiguration.EntitiesConfigurations;
public class CarTypeConfiguration : IEntityTypeConfiguration<CarType>
{
	public void Configure(EntityTypeBuilder<CarType> builder)
	{
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

		builder.Property(c => c.Title).IsRequired(true).HasMaxLength(20);
		builder.HasIndex(c => c.Title).IsUnique();


	}
}
