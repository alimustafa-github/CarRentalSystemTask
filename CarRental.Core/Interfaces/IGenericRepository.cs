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

	/// <summary>
	/// this method will get data from database based on the propertyName and the prefix which that property starts with
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="propertyValuePrefix"></param>
	/// <returns></returns>
	Task<IEnumerable<T>> GetItemsByPropertyPrefix(string propertyName, int propertyValuePrefix);

	/// <summary>
	/// this method search for a record in the database according to propert Name 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="propertyName"></param>
	/// <param name="propertyValue"></param>
	/// <returns></returns>
	Task<T> GetEntityByPropertyAsync(string propertyName, object propertyValue);
}
