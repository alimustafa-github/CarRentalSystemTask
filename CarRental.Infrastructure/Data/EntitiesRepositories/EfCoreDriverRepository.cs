namespace CarRental.Infrastructure.Data.EntitiesRepositories;
public class EfCoreDriverRepository : EfCoreRepository<Driver, ApplicationDbContext>
{
	public EfCoreDriverRepository(ApplicationDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
	{
	}
}
