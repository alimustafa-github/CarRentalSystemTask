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
		await _mediator.Publish(new CarRentedEvent { DriverId = rentedCar.DriverId, CarId = rentedCar.CarId, Cancellation = false });
		RentedCarDto rentedCarDto = _mapper.Map<RentedCarDto>(rentedCar);
		return rentedCarDto;
	}

	public async Task DeleteRentedCarByIdAsync(object id)
	{
		RentedCar rentedCar = await _rentedCarRepository.GetByIdAsync(id);
		await _rentedCarRepository.DeleteAsync(id);
		await _mediator.Publish(new CarRentedEvent { DriverId = rentedCar.DriverId, CarId = rentedCar.CarId, Cancellation = true });
	}

	public async Task<RentedCarDto> GetRentedCarByIdAsync(object id)
	{
		RentedCar rentedCar = await _rentedCarRepository.GetByIdAsync(id);
		RentedCarDto rentedCarDto = _mapper.Map<RentedCarDto>(rentedCar);
		return rentedCarDto;
	}

	public async Task<(IEnumerable<RentedCarDto>, int)> GetRentedCarsAsync(DataRequestDto input)
	{
		IQueryable<RentedCar> query = _rentedCarRepository.GetQuery();
		if (!string.IsNullOrEmpty(input.SearchProperty) && !string.IsNullOrEmpty(input.SearchValue))
		{
			query = _rentedCarRepository.ApplySearching(query, input.SearchProperty, input.SearchValue);
		}

		int totalCount = await query.CountAsync();

		int recordsToSkip = (input.PageNumber - 1) * input.PageSize;

		query = query.Skip(recordsToSkip).Take(input.PageSize);

		if (!string.IsNullOrWhiteSpace(input.SortProperty))
		{
			query = _rentedCarRepository.ApplySorting(query, input.SortProperty, input.Ascending);
		}
		IEnumerable<RentedCar> customers = await query.ToListAsync();
		IEnumerable<RentedCarDto> customerDtos = _mapper.Map<IEnumerable<RentedCarDto>>(customers);
		return (customerDtos, totalCount);
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
		await _mediator.Publish(new CarRentedEvent { DriverId = rentedCar.DriverId, CarId = rentedCar.CarId, Cancellation = false });

		RentedCarDto rentedCarDto = _mapper.Map<RentedCarDto>(rentedCar);
		return rentedCarDto;
	}
	private async Task<RentedCarDto> SearchForRentedCarByDriverIdAsync(Guid? driverId)
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
	private async Task<RentedCarDto> SearchForRentedCarByCarIdAsync(Guid? carId)
	{
		string propertyName = "CarId";
		RentedCar car = await _rentedCarRepository.SearchForEntityAsync(propertyName, carId);
		RentedCarDto carDto = _mapper.Map<RentedCarDto>(car);
		return carDto;
	}



	public class CarRentedEvent : INotification
	{
		public Guid CarId { get; set; }
		public Guid? DriverId { get; set; }
		public bool Cancellation { get; set; } = false;
	}

}
