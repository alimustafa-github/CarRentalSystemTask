using CarRental.Core.Entities;

namespace CarRental.Core.Interfaces;
public interface IRepository<T> where T : class,IEntityBase
{
	Task<T> GetByIdAsync(object id);
	Task<IEnumerable<T>> GetAllAsync();
	Task<T> AddAsync(T entity);
	Task<T> UpdateAsync(T entity);
	Task<T> DeleteAsync(object id);

	Task<IEnumerable<T>> GetFromCacheAsync();
	Task<IEnumerable<T>> SortAsync(Func<T, IComparable> propertySelector);



	//todo : Come Back here
	///// <summary>
	///// this method will get data from database based on the propertyName and the prefix which that property starts with
	///// </summary>
	///// <param name="propertyName"></param>
	///// <param name="propertyValuePrefix"></param>
	///// <returns></returns>
	//Task<IEnumerable<T>> GetItemsByPropertyPrefix(string propertyName, int propertyValuePrefix);




	//todo : Come Back here
	/// <summary>
	/// this method search for a record in the database according to propert Name 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="propertyName"></param>
	/// <param name="propertyValue"></param>
	/// <returns></returns>
	Task<T> SearchForEntityAsync(string propertyName, object propertyValue);
}
