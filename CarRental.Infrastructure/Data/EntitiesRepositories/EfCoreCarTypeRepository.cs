namespace CarRental.Infrastructure.Data.EntitiesRepositories;
public class EfCoreCarTypeRepository : EfCoreRepository<CarType, ApplicationDbContext>
{
	public EfCoreCarTypeRepository(ApplicationDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
	{
	}
}
