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

	public async Task<(IEnumerable<CustomerDto>, int)> GetCustomersAsync(DataRequestDto input)
	{
		IQueryable<Customer> query = _customerRepository.GetQuery();
		if (!string.IsNullOrEmpty(input.SearchProperty) && !string.IsNullOrEmpty(input.SearchValue))
		{
			query = _customerRepository.ApplySearching(query, input.SearchProperty, input.SearchValue);
		}

		int totalCount = await query.CountAsync();

		int recordsToSkip = (input.PageNumber - 1) * input.PageSize;

		query = query.Skip(recordsToSkip).Take(input.PageSize);

		if (!string.IsNullOrWhiteSpace(input.SortProperty))
		{
			query = _customerRepository.ApplySorting(query, input.SortProperty, input.Ascending);
		}
		IEnumerable<Customer> customers = await query.ToListAsync();
		IEnumerable<CustomerDto> customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
		return (customerDtos, totalCount);
	}

	public async Task<CustomerDto> GetCustomerByIdAsync(object id)
	{
		Customer customer = await _customerRepository.GetByIdAsync(id);
		CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
		return customerDto;
	}


	public async Task DeleteCustomerAsync(object id)
	{
		await _customerRepository.DeleteAsync(id);
	}

	public async Task<CustomerDto> AddCustomerAsync(AddCustomerDto addCustomerDto)
	{
		if (addCustomerDto.LicenceNumber is not null)
		{
			var licenceNumberExists = await SearchForCustomerByLicenceNumberAsync(addCustomerDto.LicenceNumber);
			if (licenceNumberExists is not null)
			{
				throw new DbUpdateException("the Licence Number you have entered already exsists");
			}
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



	private async Task<CustomerDto> SearchForCustomerByLicenceNumberAsync(string licenceNumber)
	{
		string propertyName = "LicenceNumber";
		Customer customer = await _customerRepository.SearchForEntityAsync(propertyName, licenceNumber);
		CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);

		return customerDto;
	}


}
