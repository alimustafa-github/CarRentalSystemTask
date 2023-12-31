﻿namespace CarRental.Infrastructure.Data.DataBaseConfiguration.EntitiesConfigurations;
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
	private string tableName = "Customers";

	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		builder.ToTable(tableName);

		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

		builder.HasOne(c => c.User)
			   .WithOne(u => u.Customer)
			   .HasForeignKey<Customer>(c => c.UserId)
			   .OnDelete(DeleteBehavior.Cascade);
		builder.HasIndex(c => c.UserId).IsUnique();

		builder.Property(c => c.HasLicence).IsRequired().HasDefaultValue(false);

		builder.Property(c => c.LicenceNumber).IsRequired(false);
		builder.Property(c => c.LicenceNumber).HasMaxLength(12).IsUnicode(false);
		builder.HasIndex(c => c.LicenceNumber).IsUnique();

		builder.Property(c => c.LicenseExpirationDate).IsRequired(false);

		builder.Property(c => c.JoinDate).IsRequired();



		builder.Property(c => c.MembershipId).IsRequired();
		builder.HasOne(c => c.MembershipLevel)
			   .WithMany(m => m.Customers)
			   .HasForeignKey(c => c.MembershipId)
			   .OnDelete(DeleteBehavior.Restrict);


	}
}
