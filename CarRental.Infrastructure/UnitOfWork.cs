using CarRental.Core.Interfaces;
using CarRental.Infrastructure.Data;

namespace CarRental.Infrastructure;
public class UnitOfWork<T> : IUnitOfWork<T> where T : class
{
	private readonly ApplicationDbContext _context;
	private IGenericRepository<T> _entity;

	public IGenericRepository<T> Entity
	{
		get
		{
			return _entity ?? (_entity = new GenericRepository<T>(_context));
		}
	}

    public UnitOfWork(ApplicationDbContext context)
    {
		_context = context;
	}
    public async Task Save()
	{
		await _context.SaveChangesAsync();
	}
}
