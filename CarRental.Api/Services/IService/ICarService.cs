namespace CarRental.Api.Services.IService;
public interface ICarService
{

	Task<CarDto> AddCarAsync(AddCarDto carDto);
	Task<CarDto> DeleteCarAsync(object id);
	//Task<IQueryable<CarDto>> GetCarsFromCacheAsync();
	Task<(IEnumerable<CarDto>,int)> GetCarsWithSortingAndFiltering(CarRequestDto input);

	//Task<CarDto> SearchForCarBySerialNumberAsync(int serialNumber);
	//Task<IEnumerable<CarDto>> SortCarsBySerialNumber(int pageNumber, int pageSize);
	Task<CarDto> UpdateCarAsync(object carId, UpdateCarDto carDto);
	Task<CarDto> GetCarByIdAsync(Guid id);

	//Task<IEnumerable<CarDto>> FilterTheCarsBySerialNumber(string value, int pageNumber, int pageSize);

}