using CarRental.Core.Interfaces;
using CarRental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	private readonly ApplicationDbContext _context;
	private DbSet<T> _dbSet;

	public GenericRepository(ApplicationDbContext context)
	{
		_context = context;
		_dbSet = _context.Set<T>();
	}
	public async Task AddAsync(T entity)
	{
		await _dbSet.AddAsync(entity);
	}

	public async Task DeleteAsync(object id)
	{
		var entity = await GetByIdAsync(id);
		_dbSet.Remove(entity);
	}

	public async Task<IEnumerable<T>> GetAllAsync()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<T> GetByIdAsync(object id)
	{
		var entity = await _dbSet.FindAsync(id);
		return entity;
	}

	public void Update(T entity)
	{
		_dbSet.Attach(entity);
		_dbSet.Entry(entity).State = EntityState.Modified;
	}

	public async Task<IEnumerable<T>> SortAsync(Func<T, IComparable> propertySelector)
	{
		IEnumerable<T> values = await GetAllAsync();
		return values.OrderBy(propertySelector);
	}


}
