namespace CarRental.Api.Services;

public class CarService : ICarService, INotificationHandler<RentedCarService.CarRentedEvent>
{
	private readonly EfCoreCarRepository _carRepository;
	private readonly IMapper _mapper;
	private readonly IUserService _userService;
	private readonly IDriverService _driverService;

	public CarService(EfCoreCarRepository carRepository, IMapper mapper, IUserService userService, IDriverService driverService)
	{
		_carRepository = carRepository;
		_mapper = mapper;
		_userService = userService;
		_driverService = driverService;
	}


	public async Task<(IEnumerable<CarDto>, int)> GetCarsWithSortingAndFiltering(CarRequestDto input)
	{
		IQueryable<Car> query = _carRepository.GetQuery();

		PropertyInfo searchingProperty = typeof(Car).GetProperty(input.SearchProperty, BindingFlags.Public | BindingFlags.Instance);
		if (searchingProperty is null)
		{
			throw new InvalidOperationException("Please double check the SearchProperty is correct");
		}

		PropertyInfo sortingProperty = typeof(Car).GetProperty(input.SortingProperty, BindingFlags.Public | BindingFlags.Instance);
		if (sortingProperty is null)
		{
			throw new InvalidOperationException("Please make sure that you have entered a valid sorting property");

		}
		if (!string.IsNullOrEmpty(input.SearchProperty) && !string.IsNullOrEmpty(input.SearchValue))
		{
			query = _carRepository.ApplySearching(query, input.SearchProperty, input.SearchValue);
		}

		int totalCount = await query.CountAsync();

		int recordsToSkip = (input.PageNumber - 1) * input.PageSize;

		query = query.Skip(recordsToSkip).Take(input.PageSize);

		if (!string.IsNullOrWhiteSpace(input.SortingProperty))
		{
			query = _carRepository.ApplySorting(query, input.SortingProperty, input.Ascending);
		}

		IEnumerable<Car> cars = await query.ToListAsync();
		IEnumerable<CarDto> carDtos = _mapper.Map<IEnumerable<CarDto>>(cars);
		return (carDtos, totalCount);
	}

	public async Task<CarDto> GetCarByIdAsync(Guid id)
	{
		Car car = await _carRepository.GetByIdAsync(id);
		CarDto carDto = _mapper.Map<CarDto>(car);
		if (carDto is null)
		{
			throw new ArgumentNullException("Mapping Failed");
		}
		return carDto;
	}

	public async Task<CarDto> AddCarAsync(AddCarDto addCarDto)
	{
		var serialNumberIsExists = await SearchForCarBySerialNumberAsync(addCarDto.SerialNumber);
		var driverIdIsExists = await SearchForCarByDriverIdAsync(addCarDto.DriverId);
		if (serialNumberIsExists is not null)
		{
			throw new DbUpdateException("SerialNumber you have entered already exist");
		}
		if (driverIdIsExists is not null)
		{
			throw new DbUpdateException("Driver ID you have entered already exist");
		}
		if (addCarDto is null)
		{
			throw new ArgumentNullException("the addCarDto is required");
		}

		Car car = _mapper.Map<Car>(addCarDto);
		car = await _carRepository.AddAsync(car);
		CarDto carDto = _mapper.Map<CarDto>(car);
		if (carDto is null)
		{
			throw new ArgumentNullException("The car was successfully created but there was an error while mapping");
		}
		return carDto;
	}

	public async Task<CarDto> UpdateCarAsync(object carId, UpdateCarDto updateCarDto)
	{

		Car car = await _carRepository.GetByIdAsync(carId);
		if (car.DriverId != updateCarDto.DriverId)
		{
			var driverIdExists = await SearchForCarByDriverIdAsync(updateCarDto.DriverId);
			if (driverIdExists is not null)
			{
				throw new DbUpdateException("the driver you have selected is already taken by another car");
			}

		}
		car = _mapper.Map(updateCarDto, car);
		car = await _carRepository.UpdateAsync(car);
		CarDto carDto = _mapper.Map<CarDto>(car);
		if (carDto is null)
		{
			throw new ArgumentNullException("The car was successfully updated but there was an error while mapping");
		}
		return carDto;
	}

	public async Task<CarDto> DeleteCarAsync(object id)
	{
		Car car = await _carRepository.DeleteAsync(id);
		CarDto carDto = _mapper.Map<CarDto>(car);
		if (carDto is null)
		{
			throw new ArgumentNullException("The car was successfully deleted but there was an error while mapping");
		}
		return carDto;
	}

	private async Task<CarDto> SearchForCarBySerialNumberAsync(int serialNumber)
	{
		string propertyName = "SerialNumber";
		Car car = await _carRepository.SearchForEntityAsync(propertyName, serialNumber.ToString());
		CarDto carDto = _mapper.Map<CarDto>(car);
		return carDto;
	}
	private async Task<CarDto> SearchForCarByDriverIdAsync(Guid? driverId)
	{
		IQueryable<Car> carsQuery = _carRepository.GetQuery();
		var car = await carsQuery.FirstOrDefaultAsync(car => car.DriverId == driverId);

		CarDto carDto = _mapper.Map<CarDto>(car);
		return carDto;
	}


	public async Task Handle(RentedCarService.CarRentedEvent notification, CancellationToken cancellationToken)
	{
		CarDto carDto = await GetCarByIdAsync(notification.CarId);
		if (carDto is not null)
		{
			carDto.IsRented = notification.Cancellation == true ? false : true;
			UpdateCarDto updateCarDto = _mapper.Map<UpdateCarDto>(carDto);
			await UpdateCarAsync(carDto.Id, updateCarDto);
		}
	}


}
