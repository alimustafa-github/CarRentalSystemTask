using CarRental.Api.Dtos.DriverDtos;

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

	public async Task<IEnumerable<CustomerDto>> GetCustomersFromCacheAsync(int pageNumber, int pageSize)
	{
		IEnumerable<Customer> customers = await _customerRepository.GetFromCacheAsync(pageNumber, pageSize);
		return _mapper.Map<IEnumerable<CustomerDto>>(customers);
	}
	public async Task<IEnumerable<CustomerDto>> GetCustomersAsync(int pageNumber, int pageSize)
	{
		IEnumerable<Customer> customers = await _customerRepository.GetAllAsync(pageNumber, pageSize);
		return _mapper.Map<IEnumerable<CustomerDto>>(customers);
	}

	public async Task<CustomerDto> GetCustomerByIdAsync(object id)
	{
		Customer customer = await _customerRepository.GetByIdAsync(id);
		CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
		return customerDto;
	}


	public async Task<CustomerDto> DeleteCustomerAsync(object id)
	{
		Customer customer = await _customerRepository.DeleteAsync(id);
		CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
		return customerDto;
	}

	public async Task<CustomerDto> AddCustomerAsync(AddCustomerDto addCustomerDto)
	{
		var licenceNumberExists = await SearchForCustomerByLicenceNumberAsync(addCustomerDto.LicenseNumber);
		if (licenceNumberExists is not null)
		{
			throw new DbUpdateException("the Licence Number you have entered already exsists");
		}
		Customer customer = _mapper.Map<Customer>(addCustomerDto);
		if (customer is null || customer.User is null)
		{
			throw new ArgumentNullException("Please Check that the Inputs are correct");
		}
		customer.UserId = customer.User.Id;
		customer.User.IsCustomer = true;
		await _customerRepository.AddAsync(customer);
		CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
		if (customerDto is null)
		{
			throw new ArgumentNullException("The Driver was Successfully Added but there was error while mapping");
		}
		return customerDto;
	}





	public async Task<CustomerDto> SearchForCustomerByLicenceNumberAsync(string licenceNumber)
	{
		string propertyName = "LicenceNumber";
		Customer customer = await _customerRepository.SearchForEntityAsync(propertyName, licenceNumber);
		CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);

		return customerDto;
	}

	public async Task<IEnumerable<CustomerDto>> SortCustomersById(int pageNumber, int pageSize)
	{
		IEnumerable<Customer> customers = await _customerRepository.SortAsync(d => d.Id, pageNumber, pageSize);


		return _mapper.Map<IEnumerable<CustomerDto>>(customers);
	}
}
