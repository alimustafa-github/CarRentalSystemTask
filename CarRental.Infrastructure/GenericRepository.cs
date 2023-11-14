using CarRental.Core.Interfaces;
using CarRental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;
using System.Reflection;

namespace CarRental.Infrastructure;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	private readonly ApplicationDbContext _context;
	private readonly IMemoryCache _memoryCache;
	private DbSet<T> _dbSet;

	public GenericRepository(ApplicationDbContext context, IMemoryCache memoryCache)
	{
		_context = context;
		_memoryCache = memoryCache;
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


	/// <summary>
	/// this method will sort the data based on the property we have provided as a lamdba expression
	/// </summary>
	/// <param name="propertySelector"></param>
	/// <returns></returns>
	public async Task<IEnumerable<T>> SortAsync(Func<T, IComparable> propertySelector)
	{
		IEnumerable<T> values = await GetAllAsync();
		return values.OrderBy(propertySelector);
	}

	public async Task<IEnumerable<T>> GetAllFromCache()
	{
		IEnumerable<T> entities = _memoryCache.Get<IEnumerable<T>>("caching");

		if (entities is null)
		{
			entities = await GetAllAsync();
			//the data will stay in Cache for two minutes
			_memoryCache.Set("caching", entities, TimeSpan.FromMinutes(2));
		}

		return entities;
	}

	public async Task<IEnumerable<T>> GetItemsByPropertyPrefix(string propertyName, int propertyValuePrefix)
	{
		var items = await _dbSet.ToListAsync();

		var filteredItems = items
			.Where(item =>
			{
				var propertyValue = GetPropertyValue(item, propertyName);
				return propertyValue != null && propertyValue.ToString().StartsWith(propertyValuePrefix.ToString());
			});

		return filteredItems.ToList();
	}
	private object GetPropertyValue(object obj, string propertyName)
	{
		PropertyInfo property = obj.GetType().GetProperty(propertyName);
		return property?.GetValue(obj);
	}



	/// <summary>
	/// this method will search for a record in the database according to the propertyName , and its value
	/// </summary>
	/// <param name="propertyName">The property we want to search accordinally</param>
	/// <param name="propertyValue">the value of that property</param>
	/// <returns></returns>
	public async Task<T?> GetEntityByPropertyAsync(string propertyName, object propertyValue)
	{
		var entityType = typeof(T);
		var parameter = Expression.Parameter(entityType, "e");
		var property = Expression.Property(parameter, propertyName);
		var equals = Expression.Equal(property, Expression.Constant(propertyValue));
		var lambda = Expression.Lambda<Func<T, bool>>(equals, parameter);

		var entity = await _dbSet.FirstOrDefaultAsync(lambda);

		return (T?)entity;
	}
}
