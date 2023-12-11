namespace CarRental.Api.Services;

public class DriverService : IDriverService, INotificationHandler<RentedCarService.CarRentedEvent>
{
	private readonly IUserService _userService;
	private readonly EfCoreDriverRepository _driverRepository;
	private readonly IMapper _mapper;

	public DriverService(IUserService userService, EfCoreDriverRepository driverRepository, IMapper mapper)
	{
		_userService = userService;
		_driverRepository = driverRepository;
		_mapper = mapper;
	}

	public async Task<DriverDto> AddDriverAsync(AddDriverDto addDriverDto)
	{
		var licenceNumberExists = await SearchForDriverByLicenceNumberAsync(addDriverDto.LicenceNumber);

		if (licenceNumberExists is not null)
		{
			throw new DbUpdateException("the Licence Number you have entered already exsists");
		}
		if (addDriverDto.AlternativeDriverId is not null)
		{
			var alternativeDriverExists = await SearchForDriverByAlternativeDriverIdAsync(addDriverDto.AlternativeDriverId);

			if (alternativeDriverExists is not null)
			{
				throw new DbUpdateException("the alternative Driver you have entered already exsists");
			}
		}
		Driver driver = _mapper.Map<Driver>(addDriverDto);
		if (driver is null || driver.User is null)
		{
			throw new ArgumentNullException("Please Check that the Inputs are correct");
		}

		driver.UserId = driver.User.Id;
		driver.User.IsDriver = true;       

		await _driverRepository.AddAsync(driver);
		DriverDto driverDto = _mapper.Map<DriverDto>(driver);
		if (driverDto is null)
		{
			throw new ArgumentNullException("The Driver was Successfully Added but there was error while mapping");
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
		IEnumerable<ApplicationUserDto> userDtos = await _userService.GetAllUsersAsync();
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

	public async Task<DriverDto> SearchForDriverByAlternativeDriverIdAsync(Guid? altDriverId)
	{
		string propertyName = "AlternativeDriverId";
		Driver driver = await _driverRepository.SearchForEntityAsync(propertyName, altDriverId);
		DriverDto driverDto = _mapper.Map<DriverDto>(driver);

		return driverDto;
	}


	public async Task<IEnumerable<DriverDto>> FilterByLicenceNumberAsync(string value,int pageNumber, int pageSize)
	{
		string propertyName = "LicenceNumber";
		IEnumerable<Driver> drivers = await _driverRepository.FilterTheRecords(propertyName, value,pageNumber,pageSize);
		IEnumerable<DriverDto> driverDtos = _mapper.Map<IEnumerable<DriverDto>>(drivers);

		return driverDtos;
	}


	public async Task Handle(RentedCarService.CarRentedEvent notification, CancellationToken cancellationToken)
	{
		Driver driver = await _driverRepository.GetByIdAsync(notification.DriverId);
		if (driver is not null)
		{
			driver.IsAvailable = notification.Cancellation == true ? true : false;
			await _driverRepository.UpdateAsync(driver);
		}
	}
}
