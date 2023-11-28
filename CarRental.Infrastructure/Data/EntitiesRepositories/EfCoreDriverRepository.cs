using CarRental.Core.Entities;

namespace CarRental.Infrastructure.Data.EntitiesRepositories;
public class EfCoreDriverRepository : EfCoreRepository<Driver, ApplicationDbContext>
{
	public EfCoreDriverRepository(ApplicationDbContext context) : base(context)
	{
	}
}
