using CarRental.Core.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CarRental.Infrastructure.Data.EntitiesRepositories;
public class EfCoreCustomerRepository : EfCoreRepository<Customer, ApplicationDbContext>
{
	public EfCoreCustomerRepository(ApplicationDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
	{
	}
}
