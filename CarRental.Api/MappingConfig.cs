namespace CarRental.Api;

public class MappingConfig
{
	public static MapperConfiguration RegisterMaps()
	{
		var mappingConfig = new MapperConfiguration(config =>
		{
			config.CreateMap<UpdateCarDto, Car>()
				.ForMember(dest => dest.IsRented, opt => opt.MapFrom(src => src.IsRented))
		   		.ForMember(d => d.DriverId, d => d.MapFrom(src => src.DriverId)).
				 ForMember(d => d.DailyFaire, d => d.MapFrom(src => src.DailyFaire)).ReverseMap();


			config.CreateMap<Car, AddCarDto>().ReverseMap();
			//config.CreateMap<Car, UpdateCarDto>().ReverseMap();
			config.CreateMap<Car, CarDto>().ReverseMap();

			config.CreateMap<ApplicationUser, RegistrationRequestDto>().ReverseMap();
			config.CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
			config.CreateMap<RoleDto, IdentityRole>().ReverseMap();

			config.CreateMap<AlternativeDriverDto, Driver>().ReverseMap();
			config.CreateMap<AddDriverDto, Driver>().ReverseMap();
			config.CreateMap<DriverDto, Driver>().ReverseMap();


		});

		return mappingConfig;
	}
}
