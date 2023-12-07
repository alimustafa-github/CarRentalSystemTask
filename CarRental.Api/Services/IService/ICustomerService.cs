namespace CarRental.Api.Services.IService;
public interface ICustomerService
{
	Task<CustomerDto> DeleteCustomerAsync(object id);
	Task<CustomerDto> GetCustomerByIdAsync(object id);
	Task<IEnumerable<CustomerDto>> GetCustomersFromCacheAsync(int pageNumber, int pageSize);
	Task<IEnumerable<CustomerDto>> GetCustomersAsync(int pageNumber, int pageSize);

	Task<CustomerDto> AddCustomerAsync(AddCustomerDto addCustomerDto);
	Task<CustomerDto> SearchForCustomerByLicenceNumberAsync(string licenceNumber);
	Task<IEnumerable<CustomerDto>> SortCustomersById(int pageNumber, int pageSize);
}