using CarRental.Core.Entities;
using CarRental.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace CarRental.Infrastructure.Data;
public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
	where TEntity : class
	where TContext : DbContext
{
	private readonly TContext _context;
	private readonly IMemoryCache _memoryCache;

	public EfCoreRepository(TContext context, IMemoryCache memoryCache)
	{
		this._context = context;
		_memoryCache = memoryCache;
	}
	public async Task<TEntity> AddAsync(TEntity entity)
	{
		_context.Set<TEntity>().Add(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	public async Task<TEntity> DeleteAsync(object id)
	{
		var entity = await _context.Set<TEntity>().FindAsync(id);
		if (entity == null)
		{
			return entity;
		}

		_context.Set<TEntity>().Remove(entity);
		await _context.SaveChangesAsync();

		return entity;
	}

	public async Task<TEntity> GetByIdAsync(object id)
	{
		return await _context.Set<TEntity>().FindAsync(id);
	}

	public async Task<IEnumerable<TEntity>> GetAllAsync(int pageNumber, int pageSize)
	{
		int recordsToSkip = (pageNumber - 1) * pageSize;

		return await _context.Set<TEntity>().AsNoTracking().Skip(recordsToSkip).Take(pageSize).ToListAsync();
	}

	public async Task<TEntity> UpdateAsync(TEntity entity)
	{
		_context.Entry(entity).State = EntityState.Modified;
		await _context.SaveChangesAsync();
		return entity;
	}

	public async Task<IEnumerable<TEntity>> GetFromCacheAsync(int pageNumber, int pageSize)
	{
		IEnumerable<TEntity> entities = _memoryCache.Get<IEnumerable<TEntity>>("caching");

		if (entities is null)
		{
			entities = await GetAllAsync(pageNumber, pageSize);
			//the data will stay in Cache for two minutes
			_memoryCache.Set("caching", entities, TimeSpan.FromMinutes(2));
		}

		return entities;
	}


	/// <summary>
	/// this method will sort the data based on the property we have provided as a lamdba expression
	/// </summary>
	/// <param name="propertySelector"></param>
	/// <returns></returns>
	public async Task<IEnumerable<TEntity>> SortAsync(Func<TEntity, IComparable> propertySelector, int pageNumber, int pageSize)
	{
		int recordsToSkip = (pageNumber - 1) * pageSize;
		IEnumerable<TEntity> values = _context.Set<TEntity>().AsQueryable().OrderBy(propertySelector).Skip(recordsToSkip).Take(pageSize);
		return values;
	}

	public async Task<TEntity> SearchForEntityAsync(string propertyName, object propertyValue)
	{
		var entityType = typeof(TEntity);
		var parameter = Expression.Parameter(entityType, "e");
		var property = Expression.Property(parameter, propertyName);
		var equals = Expression.Equal(property, Expression.Constant(propertyValue));
		var lambda = Expression.Lambda<Func<TEntity, bool>>(equals, parameter);

		var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(lambda);

		return (TEntity?)entity;
	}
}
