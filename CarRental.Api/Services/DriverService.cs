using CarRental.Api.Dtos.CarDtos;
using CarRental.Core.Entities;
using Microsoft.Data.SqlClient;

namespace CarRental.Api.Services;

public class DriverService : IDriverService
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly EfCoreDriverRepository _driverRepository;
	//public event EventHandler<ApplicationUser> DriverRegistrationEvent;
	private readonly IMapper _mapper;

	public DriverService(UserManager<ApplicationUser> userManager, EfCoreDriverRepository driverRepository, IMapper mapper)
	{
		_userManager = userManager;
		_driverRepository = driverRepository;
		_mapper = mapper;
	}
	public async Task<DriverDto> AddDriverAsync(AddDriverDto addDriverDto)
	{
		try
		{
			//todo : this is not right to register the user here create an event and notify the Unit to create a new user.
			Driver driver = _mapper.Map<Driver>(addDriverDto);
			if (driver is null || driver.User is null)
			{
				throw new ArgumentNullException("Please Check that the Inputs are correct");
			}
			await _userManager.CreateAsync(driver.User);
			driver.UserId = driver.User.Id;
			await _driverRepository.AddAsync(driver);
			DriverDto driverDto = _mapper.Map<DriverDto>(driver);
			if (driverDto is null)
			{
				throw new ArgumentNullException("The driverDto object was null");
			}
			return driverDto;
		}
		//todo :  Log Then Throw 
		catch (ArgumentNullException ex)
		{
			throw;
		}
		catch (ArgumentException ex)
		{
			throw;

			// Handle ArgumentException
		}
		catch (InvalidOperationException ex)
		{
			throw;

			// Handle InvalidOperationException
		}
		catch (AggregateException ex)
		{
			throw;

			// Handle AggregateException and its inner exceptions
			foreach (var innerException in ex.InnerExceptions)
			{
				// Handle each inner exception
			}
		}
		catch (Exception ex)
		{

			throw;
		}

	}

	public async Task<DriverDto> DeleteDriverAsync(object id)
	{
		try
		{
			var driver = await _driverRepository.DeleteAsync(id);
			return _mapper.Map<DriverDto>(driver);
		}
		catch (InvalidOperationException ex)
		{
			throw;
		}
		catch(DbUpdateException ex)
		{

			throw new Exception("you are trying to delete a driver who is an alternative driver for another driver");
		}
		catch (Exception ex)
		{

			throw;
		}
	}

	public async Task<IEnumerable<DriverDto>> GetDriversAsync(int pageNumber, int pageSize)
	{
		try
		{

			IEnumerable<Driver> drivers = await _driverRepository.GetFromCacheAsync(pageNumber, pageSize);
			if (drivers is null)
			{
				throw new ArgumentNullException("There is Drivers in the Database");
			}
			return _mapper.Map<IEnumerable<DriverDto>>(drivers);
		}
		catch (ArgumentNullException ex)
		{
			throw;
		}
		catch (TaskCanceledException ex)
		{
			throw;
		}
		catch (Exception)
		{

			throw;
		}
	}

	public async Task<DriverDto> GetDriverByIdAsync(object id)
	{
		try
		{
			if (id is null)
			{
				throw new ArgumentNullException("the id value cannot be null");
			}

			Driver driver = await _driverRepository.GetByIdAsync(id);

			if (driver is null)
			{
				throw new ArgumentNullException("the Driver value cannot be null");
			}
			if (driver is not null)
			{
				return _mapper.Map<DriverDto>(driver);
			}
			return _mapper.Map<DriverDto>(driver);
		}
		catch (ArgumentNullException ex)
		{
			throw;
		}
		catch (Exception ex)
		{
			throw;
		}
	}
	public async Task<DriverDto> SearchForDriverByLicenceNumberAsync(string licenceNumber)
	{
		try
		{
			string propertyName = "LicenceNumber";
			Driver driver = await _driverRepository.SearchForEntityAsync(propertyName, licenceNumber);
			if (driver is null)
			{
				throw new ArgumentNullException("There is no Driver corresponds with the given LicenceNumber");
			}
			return _mapper.Map<DriverDto>(driver);
		}
		catch (ArgumentNullException ex)
		{
			throw;
		}
		catch (Exception ex)
		{

			throw;
		}

	}


	public async Task<IEnumerable<DriverDto>> SortDriversById(int pageNumber, int pageSize)
	{
		try
		{
			IEnumerable<Driver> drivers = await _driverRepository.SortAsync(d => d.Id, pageNumber, pageSize);
			if (drivers is null)
			{
				throw new ArgumentNullException("Something Went wrong");
			}
			return _mapper.Map<IEnumerable<DriverDto>>(drivers);
		}
		catch (ArgumentNullException ex)
		{
			throw;
		}
		catch (Exception ex)
		{

			throw;
		}
	}

}
