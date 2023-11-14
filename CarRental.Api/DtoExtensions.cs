using CarRental.Core.Dtos;
using CarRental.Core.Entities;

namespace CarRental.Api;

public static class DtoExtensions
{

	
	public static IEnumerable<CarDto> ConvertToCarDto(this IEnumerable<Car> cars)
	{
		return (from car in cars
				select new CarDto
				{
					Id = car.Id,
					Type = car.Type,
					Color	= car.Color,
					EngineCapacity = car.EngineCapacity,
					DailyFaire = car.DailyFaire,
					SerialNumber = car.SerialNumber,
					WithDriver = car.WithDriver
				}).ToList();
	}


	public static CarDto ConvertToCarDto(this Car car)
	{
		return new CarDto
		{
			Id = car.Id,
			Type = car.Type,
			Color = car.Color,
			EngineCapacity = car.EngineCapacity,
			DailyFaire = car.DailyFaire,
			SerialNumber = car.SerialNumber,
			WithDriver = car.WithDriver
		};
	}


	public static Car ConvertToCar(this CarDto carDto)
	{
		return new Car
		{
			Id = carDto.Id,
			Type = carDto.Type,
			Color = carDto.Color,
			EngineCapacity = carDto.EngineCapacity,
			DailyFaire = carDto.DailyFaire,
			SerialNumber = carDto.SerialNumber,
			WithDriver = carDto.WithDriver
		};
	}

}
