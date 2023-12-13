namespace CarRental.Infrastructure.Data.DataBaseConfiguration.EntitiesConfigurations;
/// <summary>
/// This Class will Configure all the columns needed in the Cars Table
/// </summary>
public class CarConfiguration : IEntityTypeConfiguration<Car>
{
	public void Configure(EntityTypeBuilder<Car> builder)
	{
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

		builder.Property(c => c.SerialNumber)
		.IsRequired()
		.HasMaxLength(15);
		builder.HasIndex(c => c.SerialNumber)
			.IsUnique();

		builder.HasOne(c => c.CarType)
			.WithMany(m => m.Cars)
			.HasForeignKey(d => d.CarTypeId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(c => c.DailyFaire).IsRequired();

		builder.Property(c => c.EngineCapacity).IsRequired().HasMaxLength(10);

		builder.Property(c => c.IsRented).IsRequired().HasDefaultValue(false);
	}
}
