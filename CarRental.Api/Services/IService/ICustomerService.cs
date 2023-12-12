namespace CarRental.Api.Services.IService;
public interface ICustomerService
{
	Task DeleteCustomerAsync(object id);
	Task<CustomerDto> GetCustomerByIdAsync(object id);
	//Task<IEnumerable<CustomerDto>> GetCustomersFromCacheAsync(int pageNumber, int pageSize);
	Task<(IEnumerable<CustomerDto>,int)> GetCustomersAsync(DataRequestDto input);

	Task<CustomerDto> AddCustomerAsync(AddCustomerDto addCustomerDto);

}