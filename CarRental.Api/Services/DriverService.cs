using CarRental.Api.Dtos.CarDtos;
using CarRental.Api.Dtos.DriverDtos;
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
		//todo : this is not right to register the user here create an event and notify the Responsilbe Service to create a new user.
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
			throw new ArgumentNullException("The Driver was Successfully Added to the Database but there was error while mapping");
		}
		return driverDto;

	}

	public async Task<DriverDto> DeleteDriverAsync(object id)
	{
		Driver driver = await _driverRepository.DeleteAsync(id);
		DriverDto driverDto = _mapper.Map<DriverDto>(driver);

		if (driverDto is null)
		{
			throw new ArgumentNullException("The driver was deleted but there was error while mapping");
		}
		return driverDto;
	}

	public async Task<IEnumerable<DriverDto>> GetDriversFromCacheAsync(int pageNumber, int pageSize)
	{
		IEnumerable<Driver> drivers = await _driverRepository.GetFromCacheAsync(pageNumber, pageSize);
		IEnumerable<DriverDto> driverDtos = _mapper.Map<IEnumerable<DriverDto>>(drivers);

		if (driverDtos is null)
		{
			throw new ArgumentNullException("Mapping Failed");
		}
		return driverDtos;
	}
	public async Task<IEnumerable<DriverDto>> GetDriversAsync(int pageNumber, int pageSize)
	{
		IEnumerable<Driver> drivers = await _driverRepository.GetAllAsync(pageNumber, pageSize);
		IEnumerable<DriverDto> driverDtos = _mapper.Map<IEnumerable<DriverDto>>(drivers);

		if (driverDtos is null)
		{
			throw new ArgumentNullException("Mapping Failed");
		}
		return driverDtos;
	}

	public async Task<DriverDto> GetDriverByIdAsync(object id)
	{
		if (id is null)
		{
			throw new ArgumentNullException("the id value cannot be null");
		}

		Driver driver = await _driverRepository.GetByIdAsync(id);
		DriverDto driverDto = _mapper.Map<DriverDto>(driver);

		if (driverDto is null)
		{
			throw new ArgumentNullException("Mapping Failed");
		}
		return driverDto;
	}

	public async Task<DriverDto> SearchForDriverByLicenceNumberAsync(string licenceNumber)
	{
		string propertyName = "LicenceNumber";
		Driver driver = await _driverRepository.SearchForEntityAsync(propertyName, licenceNumber);
		DriverDto driverDto = _mapper.Map<DriverDto>(driver);

		return driverDto;
	}

	public async Task<IEnumerable<DriverDto>> SortDriversById(int pageNumber, int pageSize)
	{
		IEnumerable<Driver> drivers = await _driverRepository.SortAsync(d => d.Id, pageNumber, pageSize);


		return _mapper.Map<IEnumerable<DriverDto>>(drivers);
	}


}
