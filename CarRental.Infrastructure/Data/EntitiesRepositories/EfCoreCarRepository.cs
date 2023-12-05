namespace CarRental.Infrastructure.Data.EntitiesRepositories;
public class EfCoreCarRepository : EfCoreRepository<Car, ApplicationDbContext>
{
	public EfCoreCarRepository(ApplicationDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
	{
	}

}
