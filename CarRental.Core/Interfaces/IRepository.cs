namespace CarRental.Core.Interfaces;
public interface IRepository<T> where T : class
{
	Task<T> GetByIdAsync(object id);
	Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize);
	IQueryable<T> GetQuery();
	Task<T> AddAsync(T entity);
	Task<T> UpdateAsync(T entity);
	Task<T> DeleteAsync(object id);

	Task<IEnumerable<T>> GetFromCacheAsync(int pageNumber, int pageSize);
	Task<IEnumerable<T>> SortAsync(Func<T, IComparable> propertySelector, int pageNumber, int pageSize);


	/// <summary>
	/// this method will search for records in a table based uppon the propertyName which is the a given field for that table
	/// and the value entered by the user 
	/// it looks just like this in Sql : "Select * from 'table' where 'column' like '%value%' "
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	Task<IEnumerable<T>> FilterTheRecords(string value, object propertyName, int pageNumber, int pageSize);


	/// <summary>
	/// this method search for a record in the database according to propert Name 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="propertyName"></param>
	/// <param name="propertyValue"></param>
	/// <returns></returns>
	Task<T> SearchForEntityAsync(string propertyName, object propertyValue);


	IQueryable<T> ApplySearching(IQueryable<T> query, string searchProperty, object searchValue);

	IQueryable<T> ApplySorting(IQueryable<T> query, string sortingProperty, bool ascending);

}
