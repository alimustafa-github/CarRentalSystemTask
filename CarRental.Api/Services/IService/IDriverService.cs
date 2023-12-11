namespace CarRental.Api.Services.IService;

public interface IDriverService
{
	Task<DriverDto> AddDriverAsync(AddDriverDto addDriverDto);
	Task<IEnumerable<DriverDto>> GetDriversAsync(int pageNumber, int pageSize);
	Task<DriverDto> DeleteDriverAsync(object id);

	Task<DriverDto> GetDriverByIdAsync(object id);
	Task<DriverDto> SearchForDriverByLicenceNumberAsync(string licenceNumber);
	Task<IEnumerable<DriverDto>> SortDriversById(int pageNumber, int pageSize);

	Task<IEnumerable<DriverDto>> GetDriversFromCacheAsync(int pageNumber, int pageSize);
	Task<IEnumerable<DriverDto>> FilterByLicenceNumberAsync(string value, int pageNumber, int pageSize);
}
