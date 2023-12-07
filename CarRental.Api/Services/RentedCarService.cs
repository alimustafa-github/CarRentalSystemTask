﻿namespace CarRental.Api.Services;

public class RentedCarService : IRentedCarService
{
	private readonly EfCoreRentedCarRepository _rentedCarRepository;
	private readonly IMapper _mapper;

	public RentedCarService(EfCoreRentedCarRepository rentedCarRepository, IMapper mapper)
	{
		_rentedCarRepository = rentedCarRepository;
		_mapper = mapper;
	}

	public async Task<RentedCarDto> AddRentedCarAsync(AddRentedCarDto addRentedCarDto)
	{
		RentedCar rentedCar = _mapper.Map<RentedCar>(addRentedCarDto);
		rentedCar = await _rentedCarRepository.AddAsync(rentedCar);
		RentedCarDto rentedCarDto = _mapper.Map<RentedCarDto>(rentedCar);
		return rentedCarDto;
	}

	public async Task<RentedCarDto> DeleteRentedCarByIdAsync(object id)
	{
		RentedCar rentedCar = await _rentedCarRepository.GetByIdAsync(id);
		rentedCar = await _rentedCarRepository.DeleteAsync(id);
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
		RentedCar rentedCar = await _rentedCarRepository.GetByIdAsync(id);
		rentedCar = _mapper.Map(updateRentedCarDto, rentedCar);
		rentedCar = await _rentedCarRepository.UpdateAsync(rentedCar);
		RentedCarDto rentedCarDto = _mapper.Map<RentedCarDto>(rentedCar);
		return rentedCarDto;
	}
}