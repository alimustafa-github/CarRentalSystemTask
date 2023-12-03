using CarRental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.DataBaseConfiguration.EntitiesConfigurations;
public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
{
	public void Configure(EntityTypeBuilder<Membership> builder)
	{
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

		builder.Property(c => c.Level).IsRequired(true).IsUnicode(false).HasMaxLength(12);
	}
}
