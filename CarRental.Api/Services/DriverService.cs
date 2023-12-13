namespace CarRental.Api.Services;

public class DriverService : IDriverService, INotificationHandler<RentedCarService.CarRentedEvent>
{
	private readonly EfCoreDriverRepository _driverRepository;
	private readonly IMapper _mapper;

	public DriverService(EfCoreDriverRepository driverRepository, IMapper mapper)
	{
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

	public async Task DeleteDriverAsync(object id)
	{
		await _driverRepository.DeleteAsync(id);
	}

	public async Task<(IEnumerable<DriverDto>, int)> GetDriversAsync(DataRequestDto input)
	{
		IQueryable<Driver> query = _driverRepository.GetQuery();
		if (!string.IsNullOrEmpty(input.SearchProperty) && !string.IsNullOrEmpty(input.SearchValue))
		{
			query = _driverRepository.ApplySearching(query, input.SearchProperty, input.SearchValue);
		}

		int totalCount = await query.CountAsync();

		int recordsToSkip = (input.PageNumber - 1) * input.PageSize;

		query = query.Skip(recordsToSkip).Take(input.PageSize);
		if (!string.IsNullOrWhiteSpace(input.SortProperty))
		{
			query = _driverRepository.ApplySorting(query, input.SortProperty, input.Ascending);
		}
		IEnumerable<Driver> drivers = await query.ToListAsync();
		IEnumerable<DriverDto> driverDtos = _mapper.Map<IEnumerable<DriverDto>>(drivers);
		return (driverDtos, totalCount);

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

	private async Task<DriverDto> SearchForDriverByLicenceNumberAsync(string licenceNumber)
	{
		string propertyName = "LicenceNumber";
		Driver driver = await _driverRepository.SearchForEntityAsync(propertyName, licenceNumber);
		DriverDto driverDto = _mapper.Map<DriverDto>(driver);

		return driverDto;
	}


	private async Task<DriverDto> SearchForDriverByAlternativeDriverIdAsync(Guid? altDriverId)
	{
		string propertyName = "AlternativeDriverId";
		Driver driver = await _driverRepository.SearchForEntityAsync(propertyName, altDriverId);
		DriverDto driverDto = _mapper.Map<DriverDto>(driver);

		return driverDto;
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
