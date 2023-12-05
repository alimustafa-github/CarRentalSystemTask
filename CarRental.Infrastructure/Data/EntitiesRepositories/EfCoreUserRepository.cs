namespace CarRental.Infrastructure.Data.EntitiesRepositories;
public class EfCoreUserRepository : EfCoreRepository<ApplicationUser, ApplicationDbContext>
{
	public EfCoreUserRepository(ApplicationDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
	{
	}

}



