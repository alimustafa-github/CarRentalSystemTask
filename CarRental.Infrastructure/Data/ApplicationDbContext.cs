using CarRental.Core.Entities;
using CarRental.Infrastructure.Data.DataBaseConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<Car> Cars { get; set; }
	public DbSet<Driver> Drivers { get; set; }
	public DbSet<RentedCar> RentedCars { get; set; }
	public DbSet<Customer> Customers { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		//Configure the Tables 
		modelBuilder.ApplyConfiguration(new CarConfiguration());
		modelBuilder.ApplyConfiguration(new DriverConfiguration());
		modelBuilder.ApplyConfiguration(new RentedCarConfiguration());
	}
}

