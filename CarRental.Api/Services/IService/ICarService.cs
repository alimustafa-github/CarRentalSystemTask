namespace CarRental.Api.Services.IService;
public interface ICarService
{
	Task<CarDto> AddCarAsync(AddCarDto carDto);
	Task<CarDto> DeleteCarAsync(object id);
	Task<IEnumerable<CarDto>> GetCarsAsync(int numberToSkip, int numberToTake);
	Task<CarDto> SearchForCarBySerialNumberAsync(int serialNumber);
	Task<IEnumerable<CarDto>> SortCarsBySerialNumber(int numberToSkip, int numberToTake);
	Task<CarDto> UpdateCarAsync(object carId, UpdateCarDto carDto);
	Task<CarDto> GetCarByIdAsync(Guid id);

	Task<IEnumerable<CarDto>> FilterTheCarsBySerialNumber(string value);

}