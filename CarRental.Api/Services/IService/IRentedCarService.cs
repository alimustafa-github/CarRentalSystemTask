namespace CarRental.Api.Services.IService;

public interface IRentedCarService
{
	Task<RentedCarDto> GetRentedCarByIdAsync(object id);
	Task<IEnumerable<RentedCarDto>> GetRentedCarsAsync(int pageNumber, int pageSize);
	Task<RentedCarDto> AddRentedCarAsync(AddRentedCarDto addRentedCarDto);
	Task<RentedCarDto> UpdateRentedCarAsync(object id, UpdateRentedCarDto updateRentedCarDto);
	Task<RentedCarDto> DeleteRentedCarByIdAsync(object id);
	Task<IEnumerable<RentedCarDto>> GetRentedCarsFromChacheAsync(int pageNumber, int pageSize);

}
