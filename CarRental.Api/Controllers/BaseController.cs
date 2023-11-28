using CarRental.Core.Entities;
using CarRental.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<TEntity,TRepository> : ControllerBase
	where TEntity : class,IEntityBase
	where TRepository : IRepository<TEntity>
{
	private readonly TRepository _repository;

	public BaseController(TRepository repository)
    {
		_repository = repository;
	}

}
