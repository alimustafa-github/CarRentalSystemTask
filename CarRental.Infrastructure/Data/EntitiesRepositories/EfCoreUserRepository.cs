using CarRental.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace CarRental.Infrastructure.Data.EntitiesRepositories;
public class EfCoreUserRepository : EfCoreRepository<ApplicationUser, ApplicationDbContext>
{
	public EfCoreUserRepository(ApplicationDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
	{
	}

}



