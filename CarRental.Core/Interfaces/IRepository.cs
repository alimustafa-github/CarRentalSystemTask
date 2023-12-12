namespace CarRental.Core.Interfaces;
public interface IRepository<T> where T : class
{
	Task<T> GetByIdAsync(object id);
	IQueryable<T> GetQuery();
	Task<T> AddAsync(T entity);
	Task<T> UpdateAsync(T entity);
	Task DeleteAsync(object id);

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
