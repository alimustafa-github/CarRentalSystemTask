using CarRental.Core.Interfaces;
using CarRental.Infrastructure.Data;
using Microsoft.Extensions.Caching.Memory;

namespace CarRental.Infrastructure;
public class UnitOfWork<T> : IUnitOfWork<T> where T : class
{
	private readonly ApplicationDbContext _context;
	private readonly IMemoryCache _memoryCache;
	private IGenericRepository<T> _entity;

	public IGenericRepository<T> Entity
	{
		get
		{
			return _entity ?? (_entity = new GenericRepository<T>(_context, _memoryCache));
		}
	}

    public UnitOfWork(ApplicationDbContext context,IMemoryCache memoryCache)
    {
		_context = context;
		_memoryCache = memoryCache;
	}
    public async Task Save()
	{
		await _context.SaveChangesAsync();
	}
}
