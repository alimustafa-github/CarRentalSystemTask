namespace CarRental.Api;

public class MappingConfig
{

	public static MapperConfiguration RegisterMaps()
	{
		var mappingConfig = new MapperConfiguration(config =>
		{

			config.CreateMap<UpdateCarDto, Car>().ReverseMap();
			config.CreateMap<UpdateCarDto, CarDto>().ReverseMap();

			config.CreateMap<Car, AddCarDto>().ReverseMap();
			config.CreateMap<Car, CarDto>().ReverseMap();

			config.CreateMap<ApplicationUser, RegistrationRequestDto>().ReverseMap();
			config.CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
			config.CreateMap<RoleDto, IdentityRole>().ReverseMap();

			config.CreateMap<AddDriverDto, Driver>().ReverseMap();
			config.CreateMap<DriverDto, Driver>().ReverseMap();

			config.CreateMap<Customer,AddCustomerDto>().ReverseMap();
			config.CreateMap<Customer, CustomerDto>().ReverseMap();


			config.CreateMap<RentedCar, AddRentedCarDto>().ReverseMap();
			config.CreateMap<RentedCar, UpdateRentedCarDto>().ReverseMap();
			config.CreateMap<RentedCar, RentedCarDto>().ReverseMap();
		});

		return mappingConfig;
	}
}
