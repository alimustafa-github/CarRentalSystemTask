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
		if (cars is not null)
		{
			return (from car in cars
					select new CarDto
					{
						Id = car.Id,
						Type = car.Type,
						Color = car.Color,
						EngineCapacity = car.EngineCapacity,
						DailyFaire = car.DailyFaire,
						SerialNumber = car.SerialNumber,
						WithDriver = car.WithDriver
					}).ToList();
		}
		else
		{
			return null;
		}

	}


	public static CarDto ConvertToCarDto(this Car car)
	{
		if (car is not not)
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
		else
		{
			return null;
		}


	}


	public static Car ConvertToCar(this CarDto carDto)
	{
		if (carDto is not null)
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
		else
		{
			return null;
		}

	}

}
