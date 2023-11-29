using CarRental.Core.Entities;
using CarRental.Infrastructure.Data.DataBaseConfiguration;
using CarRental.Infrastructure.Data.DataBaseConfiguration.EntitiesConfigurations;
using CarRental.Infrastructure.Data.DataBaseConfiguration.IdentityConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<Car> Cars { get; set; }
	public DbSet<Driver> Drivers { get; set; }
	public DbSet<RentedCar> RentedCars { get; set; }
	public DbSet<Customer> Customers { get; set; }
	public static DbSet<ApplicationUser> ApplicationUsers { get; set; }
	public static DbSet<IdentityRole> ApplicationRoles { get; set; }
	public static DbSet<IdentityUserRole<string>> ApplicationUserRoles { get; set; }
	public static DbSet<IdentityUserClaim<string>> ApplicationUserClaims { get; set; }
	public static DbSet<IdentityRoleClaim<string>> ApplicationRoleClaims { get; set; }
	public static DbSet<IdentityUserLogin<string>> ApplicationUserLogins { get; set; }
	public static DbSet<IdentityUserToken<string>> ApplicationUserTokens { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		//Configure the Tables 
		modelBuilder.ApplyConfiguration(new CarConfiguration());
		modelBuilder.ApplyConfiguration(new DriverConfiguration());
		modelBuilder.ApplyConfiguration(new RentedCarConfiguration());
		modelBuilder.ApplyConfiguration(new CustomerConfiguration());

		ApplyIdentityTablesConfigurations(modelBuilder);
	}


	private void ApplyIdentityTablesConfigurations(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
		modelBuilder.ApplyConfiguration(new ApplicationRoleConfiguration());
		modelBuilder.ApplyConfiguration(new ApplicationUserRoleConfiguration());
		modelBuilder.ApplyConfiguration(new ApplicationUserClaimConfiguration());
		modelBuilder.ApplyConfiguration(new ApplicationUserLoginConfiguration());
		modelBuilder.ApplyConfiguration(new ApplicationUserTokenConfiguration());
		modelBuilder.ApplyConfiguration(new ApplicationRoleClaimConfiguration());

	}
}

