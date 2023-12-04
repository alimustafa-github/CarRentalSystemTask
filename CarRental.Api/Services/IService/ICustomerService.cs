namespace CarRental.Api.Services.IService;
public interface ICustomerService
{
    Task<CustomerDto> DeleteCustomerAsync(object id);
    Task<CustomerDto> GetCustomerByIdAsync(object id);
    Task<IEnumerable<CustomerDto>> GetCustomersAsync(int pageNumber, int pageSize);
    Task<CustomerDto> UpdateCustomerAsync(object carId, UpdateCustomerDto updateCustomerDto);
}