using CarRental.Core.Dtos;
using CarRental.Core.Entities;

namespace CarRental.Api;
/// <summary>
/// this class is responsible for Mapping from one object to a dto of that object
/// I usually use AutoMapper for Mapping but for simplification purposes I have mapped them manually using extension methods
/// </summary>
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
