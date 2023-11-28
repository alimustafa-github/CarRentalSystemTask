using CarRental.Api.Dtos;

namespace CarRental.Api.Services;
public interface ICarService
{
	Task<CarDto> AddCarAsync(CarDto carDto);
	Task<CarDto> DeleteCarAsync(object id);
	Task<IEnumerable<CarDto>> GetCarsAsync(int numberToSkip, int numberToTake);
	Task<CarDto> SearchForCarBySerialNumberAsync(int serialNumber);
	Task<IEnumerable<CarDto>> SortCarsBySerialNumber(int numberToSkip, int numberToTake);
	Task<CarDto> UpdateCarAsync(CarDto carDto);
	Task<CarDto> GetCarByIdAsync(Guid id);
}