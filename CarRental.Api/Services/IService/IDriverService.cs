namespace CarRental.Api.Services.IService;

public interface IDriverService
{
	Task<DriverDto> AddDriverAsync(AddDriverDto addDriverDto);
	Task<(IEnumerable<DriverDto>, int)> GetDriversAsync(DataRequestDto input);
	Task DeleteDriverAsync(object id);

	Task<DriverDto> GetDriverByIdAsync(object id);

}
