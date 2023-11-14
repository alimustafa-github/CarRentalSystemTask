using AutoMapper;
using CarRental.Core.Dtos;
using CarRental.Core.Entities;

namespace CarRental.Api;

public class MappingConfig
{
	public static MapperConfiguration RegisterMaps()
	{
		MapperConfiguration mappingConfig = new(config =>
		{
			config.CreateMap<IEnumerable<CarDto>, IEnumerable<Car>>().ReverseMap();
			config.CreateMap<CarDto, Car>().ReverseMap();
		});
		return mappingConfig;
	}
}
