namespace CarRental.Infrastructure.Data.EntitiesRepositories;
public class EfCoreRentedCarRepository : EfCoreRepository<RentedCar, ApplicationDbContext>
{
	public EfCoreRentedCarRepository(ApplicationDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
	{
	}
}
