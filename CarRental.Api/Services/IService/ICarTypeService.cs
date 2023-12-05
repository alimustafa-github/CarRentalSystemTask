namespace CarRental.Api.Services.IService;

public interface ICarTypeService
{
    Task<CarTypeDto> AddCarAsync(AddCarTypeDto addCarTypeDto);
    Task<CarTypeDto> DeleteCarAsync(object id);
    Task<CarTypeDto> GetCarByIdAsync(Guid id);
    Task<IEnumerable<CarTypeDto>> GetCarTypesAsync(int pageNumber, int pageSize);
    Task<CarTypeDto> UpdateCarAsync(object carId, UpdateCarTypeDto updateCarTypeDto);
}
