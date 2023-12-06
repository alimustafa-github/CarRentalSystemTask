namespace CarRental.Api.Services.IService;
public interface ICarService
{
	Task<CarDto> AddCarAsync(AddCarDto carDto);
	Task<CarDto> DeleteCarAsync(object id);
	Task<IEnumerable<CarDto>> GetCarsFromCacheAsync(int pageNumber, int pageSize);
	Task<IEnumerable<CarDto>> GetCarsAsync(int pageNumber, int pageSize);

	Task<CarDto> SearchForCarBySerialNumberAsync(int serialNumber);
	Task<IEnumerable<CarDto>> SortCarsBySerialNumber(int pageNumber, int pageSize);
	Task<CarDto> UpdateCarAsync(object carId, UpdateCarDto carDto);
	Task<CarDto> GetCarByIdAsync(Guid id);

	Task<IEnumerable<CarDto>> FilterTheCarsBySerialNumber(string value);

}