using System.Runtime.InteropServices;

namespace CarRental.Api.Services;

public class CarService : ICarService
{
	private readonly EfCoreCarRepository _carRepository;
	private readonly IMapper _mapper;

	public CarService(EfCoreCarRepository carRepository, IMapper mapper)
	{
		_carRepository = carRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CarDto>> GetCarsAsync(int pageNumber, int pageSize)
	{
		try
		{
			IEnumerable<Car> cars = await _carRepository.GetFromCacheAsync(pageNumber, pageSize);
			if (cars is null)
			{
				throw new ArgumentNullException(nameof(cars));
			}
			return _mapper.Map<IEnumerable<CarDto>>(cars);
		}
		catch (ArgumentNullException ex)
		{
			throw;
		}
		catch (DbUpdateException ex)
		{
			throw;
		}
		catch (Exception ex)
		{
			throw;
		}
	}

	public async Task<CarDto> GetCarByIdAsync(Guid id)
	{
		try
		{
			Car car = await _carRepository.GetByIdAsync(id);
			if (car is null)
			{
				throw new ArgumentNullException(nameof(car));
			}
			return _mapper.Map<CarDto>(car);
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

	public async Task<CarDto> AddCarAsync(AddCarDto addCarDto)
	{
		try
		{
			if (addCarDto is null)
			{
				throw new ArgumentNullException();
			}

			Car car = _mapper.Map<Car>(addCarDto);
			car = await _carRepository.AddAsync(car);
			CarDto carDto = _mapper.Map<CarDto>(car);
			return carDto;
		}
		catch (ArgumentNullException ex)
		{
			throw;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public async Task<CarDto> UpdateCarAsync(object carId, UpdateCarDto updateCarDto)
	{
		if (updateCarDto is not null && carId is not null)
		{

			Car car = await _carRepository.GetByIdAsync(carId);
			if (car is not null)
			{
				//car = _mapper.Map<Car>(updateCarDto);
				car = _mapper.Map(updateCarDto, car);
				await _carRepository.UpdateAsync(car);
				return _mapper.Map<CarDto>(car);
			}
			else
			{
				throw new InvalidOperationException();
			}

		}
		else
		{
			return null;
		}
	}

	public async Task<CarDto> DeleteCarAsync(object id)
	{
		Car car = await _carRepository.DeleteAsync(id);
		if (car is not null)
		{
			CarDto carDto = _mapper.Map<CarDto>(car);
			return carDto;
		}
		return null;
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
		//todo : handle the errors if any 
		string propertyName = "SerialNumber";
		IEnumerable<Car> cars = await _carRepository.FilterTheRecords(propertyName, value);
		IEnumerable<CarDto> carDtos = _mapper.Map<IEnumerable<CarDto>>(cars);
		return carDtos;
	}
}
