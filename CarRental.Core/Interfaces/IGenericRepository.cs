namespace CarRental.Core.Interfaces;
public interface IGenericRepository<T> where T : class
{
	Task<T> GetByIdAsync(object id);
	Task<IEnumerable<T>> GetAllAsync();
	Task AddAsync(T entity);
	void Update(T entity);
	Task DeleteAsync(object id);

	Task<IEnumerable<T>> GetAllFromCache();
	Task<IEnumerable<T>> SortAsync(Func<T, IComparable> propertySelector);
}
