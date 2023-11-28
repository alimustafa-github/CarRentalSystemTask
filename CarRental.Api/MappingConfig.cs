using AutoMapper;
using CarRental.Api.Dtos;
using CarRental.Core.Entities;

namespace CarRental.Api;

public class MappingConfig
{
	public static MapperConfiguration RegisterMaps()
	{
		var mappingConfig = new MapperConfiguration(config =>
		{
			config.CreateMap<Car, CarDto>().ReverseMap();
		});

		return mappingConfig;
	}
}
