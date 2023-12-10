namespace CarRental.Api.Services;

public class RentedCarService : IRentedCarService
{
	private readonly EfCoreRentedCarRepository _rentedCarRepository;
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	public RentedCarService(EfCoreRentedCarRepository rentedCarRepository, IMapper mapper, IMediator mediator)
	{
		_rentedCarRepository = rentedCarRepository;
		_mapper = mapper;
		_mediator = mediator;
	}



	public async Task<RentedCarDto> AddRentedCarAsync(AddRentedCarDto addRentedCarDto)
	{
		var carIdIsExists = await SearchForRentedCarByCarIdAsync(addRentedCarDto.CarId);
		var driverIdIsExists = await SearchForRentedCarByDriverIdAsync(addRentedCarDto.DriverId);
		if (carIdIsExists is not null)
		{
			throw new DbUpdateException("carID you have entered already exist");

		}
		if (driverIdIsExists is not null)
		{
			throw new DbUpdateException("DriverId you have entered already exist");

		}

		RentedCar rentedCar = _mapper.Map<RentedCar>(addRentedCarDto);
		rentedCar = await _rentedCarRepository.AddAsync(rentedCar);
		_mediator.Publish(new CarRentedEvent { DriverId = rentedCar.Id, CarId = rentedCar.CarId, Cancellation = false });
		RentedCarDto rentedCarDto = _mapper.Map<RentedCarDto>(rentedCar);
		return rentedCarDto;
	}

	public async Task<RentedCarDto> DeleteRentedCarByIdAsync(object id)
	{
		RentedCar rentedCar = await _rentedCarRepository.GetByIdAsync(id);
		rentedCar = await _rentedCarRepository.DeleteAsync(id);
		_mediator.Publish(new CarRentedEvent { DriverId = rentedCar.Id, CarId = rentedCar.CarId, Cancellation = true });
		RentedCarDto rentedCarDto = _mapper.Map<RentedCarDto>(rentedCar);
		return rentedCarDto;
	}

	public async Task<RentedCarDto> GetRentedCarByIdAsync(object id)
	{
		RentedCar rentedCar = await _rentedCarRepository.GetByIdAsync(id);
		RentedCarDto rentedCarDto = _mapper.Map<RentedCarDto>(rentedCar);
		return rentedCarDto;
	}

	public async Task<IEnumerable<RentedCarDto>> GetRentedCarsAsync(int pageNumber, int pageSize)
	{
		IEnumerable<RentedCar> rentedCars = await _rentedCarRepository.GetAllAsync(pageNumber, pageSize);
		IEnumerable<RentedCarDto> rentedCarDtos = _mapper.Map<IEnumerable<RentedCarDto>>(rentedCars);
		return rentedCarDtos;
	}
	public async Task<IEnumerable<RentedCarDto>> GetRentedCarsFromChacheAsync(int pageNumber, int pageSize)
	{
		IEnumerable<RentedCar> rentedCars = await _rentedCarRepository.GetFromCacheAsync(pageNumber, pageSize);
		IEnumerable<RentedCarDto> rentedCarDtos = _mapper.Map<IEnumerable<RentedCarDto>>(rentedCars);
		return rentedCarDtos;
	}

	public async Task<RentedCarDto> UpdateRentedCarAsync(object id, UpdateRentedCarDto updateRentedCarDto)
	{
		var carIdIsExists = await SearchForRentedCarByCarIdAsync(updateRentedCarDto.CarId);
		if (carIdIsExists is not null)
		{
			throw new DbUpdateException("carID you have entered already exist");

		}

		RentedCar rentedCar = await _rentedCarRepository.GetByIdAsync(id);
		if (updateRentedCarDto.DriverId is not null)
		{
			if (rentedCar.DriverId != updateRentedCarDto.DriverId)
			{
				var driverIdIsExists = await SearchForRentedCarByDriverIdAsync(updateRentedCarDto.DriverId);
				if (driverIdIsExists is not null)
				{
					throw new DbUpdateException("DriverId you have entered already exist");

				}
			}
		}
	

		rentedCar = _mapper.Map(updateRentedCarDto, rentedCar);
		rentedCar = await _rentedCarRepository.UpdateAsync(rentedCar);
		_mediator.Publish(new CarRentedEvent { DriverId = rentedCar.Id, CarId = rentedCar.CarId, Cancellation = false });

		RentedCarDto rentedCarDto = _mapper.Map<RentedCarDto>(rentedCar);
		return rentedCarDto;
	}
	public async Task<RentedCarDto> SearchForRentedCarByDriverIdAsync(Guid? driverId)
	{
		if (driverId is null)
		{
			return null;
		}
		string propertyName = "DriverId";
		RentedCar car = await _rentedCarRepository.SearchForEntityAsync(propertyName, driverId);
		RentedCarDto carDto = _mapper.Map<RentedCarDto>(car);
		return carDto;
	}
	public async Task<RentedCarDto> SearchForRentedCarByCarIdAsync(Guid? carId)
	{
		string propertyName = "CarId";
		RentedCar car = await _rentedCarRepository.SearchForEntityAsync(propertyName, carId);
		RentedCarDto carDto = _mapper.Map<RentedCarDto>(car);
		return carDto;
	}

}
