﻿namespace CarRental.Infrastructure.Data;
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

	public IQueryable<TEntity> GetQuery()
	{
		return _context.Set<TEntity>().AsQueryable();
	}
	public async Task<TEntity> AddAsync(TEntity entity)
	{
		_context.Set<TEntity>().Add(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	public async Task<TEntity> DeleteAsync(object id)
	{
		if (id is null)
		{
			throw new ArgumentNullException("The Identifier must not be null");
		}
		var entity = await GetByIdAsync(id);
		if (!_context.Set<TEntity>().Local.Contains(entity))
		{
			throw new InvalidOperationException("Entity is not being tracked by the context.");
		}
		_context.Set<TEntity>().Remove(entity);
		//await Task.Run(() => _context.Set<TEntity>().Remove(entity));
		await _context.SaveChangesAsync();

		return entity;
	}

	public async Task<TEntity> GetByIdAsync(object id)
	{
		TEntity? entity = await _context.Set<TEntity>().FindAsync(id);
		if (entity is null)
		{
			throw new ArgumentNullException("There is no Entity Corresponds with the give identifier");
		}
		return entity;
	}

	public async Task<IEnumerable<TEntity>> GetAllAsync(int pageNumber, int pageSize)
	{
		int recordsToSkip = (pageNumber - 1) * pageSize;

		IEnumerable<TEntity> entities = await _context.Set<TEntity>().AsNoTracking().Skip(recordsToSkip).Take(pageSize).ToListAsync();
		if (entities is null)
		{
			throw new ArgumentNullException("no data has being retrieved");
		}
		return entities;
	}

	public async Task<IEnumerable<TEntity>> GetFromCacheAsync(int pageNumber, int pageSize)
	{
		IEnumerable<TEntity>? entities = _memoryCache.Get<IEnumerable<TEntity>>(pageNumber.ToString());

		//Task<IEnumerable<TEntity>?> entities = Task.Run(() => _memoryCache.Get<IEnumerable<TEntity>>(pageNumber.ToString()));

		if (entities is null)
		{
			entities = await GetAllAsync(pageNumber, pageSize);
			//the data will stay in Cache for two minutes
			_memoryCache.Set(pageNumber.ToString(), entities, TimeSpan.FromMinutes(2));
		}
		return entities;
	}




	public async Task<TEntity> UpdateAsync(TEntity entity)
	{
		if (entity is null)
		{
			throw new ArgumentNullException("Please double check that you have entered a valid identifier");
		}
		if (!_context.Set<TEntity>().Local.Contains(entity))
		{
			throw new InvalidOperationException("Entity is not being tracked by the context.");
		}
		_context.Entry(entity).State = EntityState.Modified;
		//await Task.Run(() => _context.Entry(entity).State = EntityState.Modified);
		await _context.SaveChangesAsync();
		return entity;
	}



	/// <summary>
	/// this method will sort the data based on the property we have provided as a lamdba expression
	/// </summary>
	/// <param name="propertySelector"></param>
	/// <returns></returns>
	public async Task<IEnumerable<TEntity>> SortAsync(Func<TEntity, IComparable> propertySelector, int pageNumber, int pageSize)
	{
		if (propertySelector is null)
		{
			throw new ArgumentNullException("Please provide the property you to to sort based on");
		}
		int recordsToSkip = (pageNumber - 1) * pageSize;
		IEnumerable<TEntity> values = _context.Set<TEntity>().AsQueryable().OrderBy(propertySelector).Skip(recordsToSkip).Take(pageSize);
		return values;
	}

	public async Task<TEntity> SearchForEntityAsync(string propertyName, object propertyValue)
	{

		var entityType = typeof(TEntity);
		var parameter = Expression.Parameter(entityType, "e");
		var property = Expression.Property(parameter, propertyName);

		if (property.Type == typeof(string))
		{
			var equals = Expression.Equal(property, Expression.Constant(propertyValue));
			var lambda = Expression.Lambda<Func<TEntity, bool>>(equals, parameter);
			return await _context.Set<TEntity>().FirstOrDefaultAsync(lambda);
		}

		var propertyAsString = Expression.Call(property, "ToString", null);
		var propertyValueAsString = Expression.Constant(propertyValue?.ToString());

		var equals2 = Expression.Equal(propertyAsString, propertyValueAsString);
		var lambda2 = Expression.Lambda<Func<TEntity, bool>>(equals2, parameter);

		var entity = await _context.Set<TEntity>()
			.FirstOrDefaultAsync(lambda2);

		return entity;

	}


	/// <summary>
	/// this method will search for records in a table based uppon the propertyName which is the a given field for that table
	/// and the value entered by the user 
	/// it looks just like this in Sql : "Select * from 'table' where 'column' like '%value%' "
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public async Task<IEnumerable<TEntity>> FilterTheRecords(string propertyName, object value, int pageNumber, int pageSize)
	{
		var parameter = Expression.Parameter(typeof(TEntity));
		var propertyAccess = Expression.Property(parameter, propertyName);

		// Convert the property to a string if it's not already
		Expression convertedProperty = propertyAccess;
		if (propertyAccess.Type != typeof(string))
		{
			var toStringMethod = typeof(object).GetMethod("ToString");
			convertedProperty = Expression.Call(propertyAccess, toStringMethod);
		}

		// Create an expression representing the 'Contains' operation on the property
		var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
		var containsExpression = Expression.Call(convertedProperty, containsMethod, Expression.Constant(value.ToString(), typeof(string)));

		// Combine the property access and 'contains' expression into a lambda expression
		var lambda = Expression.Lambda<Func<TEntity, bool>>(containsExpression, parameter);

		// Use the lambda expression in a Where clause to filter the entities
		var filteredEntities = await _context.Set<TEntity>().Where(lambda).ToListAsync();

		int recordsToSkip = (pageNumber - 1) * pageSize;

		return filteredEntities.Skip(recordsToSkip).Take(pageSize);
	}



	public IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, string sortingProperty, bool ascending)
	{


		PropertyInfo propertyExists = typeof(TEntity).GetProperty(sortingProperty, BindingFlags.Public | BindingFlags.Instance);
		if (propertyExists is null)
		{
			throw new InvalidOperationException("Please make sure that you have entered a valid sorting property");

		}

		var parameter = Expression.Parameter(typeof(TEntity), "c");
		var property = Expression.Property(parameter, sortingProperty);
		var lambda = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(property, typeof(object)), parameter);

		return ascending ? query.OrderBy(lambda) : query.OrderByDescending(lambda);
	}
	public IQueryable<TEntity> ApplySearching(IQueryable<TEntity> query, string searchProperty, object searchValue)
	{
		PropertyInfo propertyExists = typeof(TEntity).GetProperty(searchProperty, BindingFlags.Public | BindingFlags.Instance);
		if (propertyExists is null)
		{
			throw new InvalidOperationException("Please double check the SearchProperty is correct");
		}
		var parameter = Expression.Parameter(typeof(TEntity));
		var propertyAccess = Expression.Property(parameter, searchProperty);

		// Convert the property to a string if it's not already
		Expression convertedProperty = propertyAccess;
		if (propertyAccess.Type != typeof(string))
		{
			var toStringMethod = typeof(object).GetMethod("ToString");
			convertedProperty = Expression.Call(propertyAccess, toStringMethod);
		}

		// Create an expression representing the 'Contains' operation on the property
		var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
		var containsExpression = Expression.Call(convertedProperty, containsMethod, Expression.Constant(searchValue.ToString(), typeof(string)));

		// Combine the property access and 'contains' expression into a lambda expression
		var lambda = Expression.Lambda<Func<TEntity, bool>>(containsExpression, parameter);

		// Use the lambda expression in a Where clause to filter the entities
		var filteredEntities = query.Where(lambda);

		return filteredEntities;

	}

}
