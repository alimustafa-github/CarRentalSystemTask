﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Interfaces;
public interface IGenericRepository<T> where T : class
{
	Task<T> GetByIdAsync(object id);
	Task<IEnumerable<T>> GetAllAsync();
	Task AddAsync(T entity);
	void Update(T entity);
	Task DeleteAsync(object id);


	Task<IEnumerable<T>> SortAsync(Func<T, IComparable> propertySelector);
}
