namespace CarRental.Api.Services.IService;

public interface IRentedCarService
{
	Task<RentedCarDto> GetRentedCarByIdAsync(object id);
	Task<(IEnumerable<RentedCarDto>, int)> GetRentedCarsAsync(DataRequestDto input);
	Task<RentedCarDto> AddRentedCarAsync(AddRentedCarDto addRentedCarDto);
	Task<RentedCarDto> UpdateRentedCarAsync(object id, UpdateRentedCarDto updateRentedCarDto);
	Task DeleteRentedCarByIdAsync(object id);
}
