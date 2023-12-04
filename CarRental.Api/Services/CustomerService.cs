
namespace CarRental.Api.Services;

public class CustomerService : ICustomerService
{
	private readonly EfCoreCustomerRepository _customerRepository;
	private readonly IMapper _mapper;

	public CustomerService(EfCoreCustomerRepository customerRepository, IMapper mapper)
	{
		_customerRepository = customerRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CustomerDto>> GetCustomersAsync(int pageNumber, int pageSize)
	{
		IQueryable<Customer> customers = _customerRepository.GetFromCacheAsync(pageNumber, pageSize).Result.AsQueryable();
		return _mapper.Map<IEnumerable<CustomerDto>>(customers);
	}

	public async Task<CarDto> GetCustomerByIdAsync(object id)
	{
		Customer customer = await _customerRepository.GetByIdAsync(id);
		if (customer is not null)
		{
			return _mapper.Map<CarDto>(customer);
		}
		return null;
	}

	public async Task<CustomerDto> UpdateCustomerAsync(object customerId, UpdateCustomerDto updateCustomerDto)
	{
		if (updateCustomerDto is not null && customerId is not null)
		{
			Customer customer = await _customerRepository.GetByIdAsync(customerId);
			customer = _mapper.Map<Customer>(updateCustomerDto);
			await _customerRepository.UpdateAsync(customer);
			return _mapper.Map<CustomerDto>(customer);
		}
		else
		{
			return null;
		}
	}

	public async Task<CustomerDto> DeleteCustomerAsync(object id)
	{
		return _mapper.Map<CustomerDto>(await _customerRepository.DeleteAsync(id));
	}

	Task<CustomerDto> ICustomerService.GetCustomerByIdAsync(object id)
	{
		throw new NotImplementedException();
	}
}
