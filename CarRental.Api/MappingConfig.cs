namespace CarRental.Api;

public class MappingConfig
{
	public static MapperConfiguration RegisterMaps()
	{
		var mappingConfig = new MapperConfiguration(config =>
		{
			config.CreateMap<Car, AddCarDto>().ReverseMap();
			config.CreateMap<Car, CarDto>().ReverseMap();
			config.CreateMap<ApplicationUser,RegistrationRequestDto>().ReverseMap();
			config.CreateMap<RoleDto, IdentityRole>().ReverseMap();
		});

		return mappingConfig;
	}
}
