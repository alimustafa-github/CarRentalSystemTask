namespace CarRental.Api.Services;

public class CarService : ICarService
{
	private readonly EfCoreCarRepository _carRepository;
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;
	private readonly IUserService _userService;
	private readonly IDriverService _driverService;

	public CarService(EfCoreCarRepository carRepository, IMapper mapper, IMediator mediator, IUserService userService, IDriverService driverService)
	{
		_carRepository = carRepository;
		_mapper = mapper;
		_mediator = mediator;
		_userService = userService;
		_driverService = driverService;
	}

	public async Task<IEnumerable<CarDto>> GetCarsFromCacheAsync(int pageNumber, int pageSize)
	{
		IEnumerable<Car> cars = await _carRepository.GetFromCacheAsync(pageNumber, pageSize);
		IEnumerable<CarDto> carDtos = _mapper.Map<IEnumerable<CarDto>>(cars);
		if (carDtos is null)
		{
			throw new ArgumentNullException("Mapping Failed");
		}
		return carDtos;

	}
	public async Task<IEnumerable<CarDto>> GetCarsAsync(int pageNumber, int pageSize)
	{
		IEnumerable<Car> cars = await _carRepository.GetAllAsync(pageNumber, pageSize);
		IEnumerable<ApplicationUserDto> userDtos = await _userService.GetAllUsersAsync();
		IEnumerable<DriverDto> driverDtos = await _driverService.GetDriversAsync(pageNumber, pageSize);

		IEnumerable<CarDto> carDtos = from car in cars
									  join driver in driverDtos on car.DriverId equals driver.Id
									  join user in userDtos on driver.UserId equals user.Id
									  select new CarDto
									  {
										  Id = car.Id,
										  DailyFaire = car.DailyFaire,
										  DriverFullName = user.FirstName + " " + user.LastName,
										  CarTypeId = car.CarTypeId,
										  IsRented = car.IsRented,
										  Color = car.Color,
										  EngineCapacity = car.EngineCapacity,
										  SerialNumber = car.SerialNumber
									  };
		if (carDtos is null)
		{
			throw new ArgumentNullException("Mapping Failed");
		}
		return carDtos;
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

	public async Task<CarDto> SearchForCarBySerialNumberAsync(int serialNumber)
	{
		string propertyName = "SerialNumber";
		Car car = await _carRepository.SearchForEntityAsync(propertyName, serialNumber);
		CarDto carDto = _mapper.Map<CarDto>(car);
		return carDto;
	}


	public async Task<IEnumerable<CarDto>> SortCarsBySerialNumber(int pageNumber, int pageSize)
	{
		IEnumerable<Car> cars = await _carRepository.SortAsync(c => c.SerialNumber, pageNumber, pageSize);
		IEnumerable<CarDto> carDtos = _mapper.Map<IEnumerable<CarDto>>(cars);
		return carDtos;

	}

	public async Task<IEnumerable<CarDto>> FilterTheCarsBySerialNumber(string value)
	{
		string propertyName = "SerialNumber";
		IEnumerable<Car> cars = await _carRepository.FilterTheRecords(propertyName, value);
		IEnumerable<CarDto> carDtos = _mapper.Map<IEnumerable<CarDto>>(cars);
		return carDtos;
	}


}
