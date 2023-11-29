using AutoMapper;
using CarRental.Api.Dtos;
using CarRental.Core.Entities;
using CarRental.Infrastructure.Data.EntitiesRepositories;
using Microsoft.EntityFrameworkCore;

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
		IQueryable<Car> cars = _carRepository.GetFromCacheAsync(pageNumber,pageSize).Result.AsQueryable();
		return _mapper.Map<IEnumerable<CarDto>>(cars);
	}

	public async Task<CarDto> GetCarByIdAsync(Guid id)
	{
		Car car = await _carRepository.GetByIdAsync(id);
		if (car is not null)
		{
			return _mapper.Map<CarDto>(car);
		}
		return null;
	}

	public async Task<CarDto> AddCarAsync(CarDto carDto)
	{
		if (carDto is not null)
		{
			Car car = _mapper.Map<Car>(carDto);
			car = await _carRepository.AddAsync(car);
			carDto = _mapper.Map<CarDto>(car);
			return carDto;
		}
		else
		{
			return null;
		}
	}

	public async Task<CarDto> UpdateCarAsync(CarDto carDto)
	{
		if (carDto is not null)
		{
			Car car = _mapper.Map<Car>(carDto);
			await _carRepository.UpdateAsync(car);
			return _mapper.Map<CarDto>(car);
		}
		else
		{
			return null;
		}
	}

	public async Task<CarDto> DeleteCarAsync(object id)
	{
		return _mapper.Map<CarDto>(await _carRepository.DeleteAsync(id));
	}

	public async Task<CarDto> SearchForCarBySerialNumberAsync(int serialNumber)
	{
		string propertyName = "SerialNumber";
		CarDto car = _mapper.Map<CarDto>(await _carRepository.SearchForEntityAsync(propertyName, serialNumber));

		return car;
	}


	public async Task<IEnumerable<CarDto>> SortCarsBySerialNumber(int pageNumber, int pageSize)
	{
		return _mapper.Map<IEnumerable<CarDto>>(await _carRepository.SortAsync(car => car.SerialNumber, pageNumber, pageSize));
	}


}
