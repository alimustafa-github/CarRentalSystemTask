namespace CarRental.Api.Services;

public class CarTypeService : ICarTypeService
{
	private readonly EfCoreCarTypeRepository _carTypeRepository;
	private readonly IMapper _mapper;

	public CarTypeService(EfCoreCarTypeRepository carRepository, IMapper mapper)
	{
		_carTypeRepository = carRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CarTypeDto>> GetCarTypesAsync(int pageNumber, int pageSize)
	{
		IQueryable<CarType> carTypes = _carTypeRepository.GetFromCacheAsync(pageNumber, pageSize).Result.AsQueryable();
		return _mapper.Map<IEnumerable<CarTypeDto>>(carTypes);
	}

	public async Task<CarTypeDto> GetCarByIdAsync(Guid id)
	{
		CarType carType = await _carTypeRepository.GetByIdAsync(id);
		if (carType is not null)
		{
			return _mapper.Map<CarTypeDto>(carType);
		}
		return null;
	}

	public async Task<CarTypeDto> AddCarAsync(AddCarTypeDto addCarTypeDto)
	{
		if (addCarTypeDto is not null)
		{
			CarType carType = _mapper.Map<CarType>(addCarTypeDto);
			carType = await _carTypeRepository.AddAsync(carType);
			CarTypeDto carDto = _mapper.Map<CarTypeDto>(carType);
			return carDto;
		}
		else
		{
			return null;
		}
	}

	public async Task<CarTypeDto> UpdateCarAsync(object carId, UpdateCarTypeDto updateCarTypeDto)
	{
		if (updateCarTypeDto is not null && carId is not null)
		{
			CarType carType = await _carTypeRepository.GetByIdAsync(carId);
			carType = _mapper.Map<CarType>(updateCarTypeDto);
			await _carTypeRepository.UpdateAsync(carType);
			return _mapper.Map<CarTypeDto>(carType);
		}
		else
		{
			return null;
		}
	}

	public async Task<CarTypeDto> DeleteCarAsync(object id)
	{
		return _mapper.Map<CarTypeDto>(await _carTypeRepository.DeleteAsync(id));
	}

}
