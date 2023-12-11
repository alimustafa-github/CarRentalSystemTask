namespace CarRental.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
	private readonly ICustomerService _customerService;

	public CustomerController(ICustomerService customerService)
	{
		_customerService = customerService;
	}


	[HttpPost("addcustomer")]
	public async Task<ApiResponse<CustomerDto>> AddCustomer([FromBody] AddCustomerDto addCustomerDto)
	{
		CustomerDto customerDto = await _customerService.AddCustomerAsync(addCustomerDto);
		return new ApiResponse<CustomerDto>
		{
			IsSuccess = true,
			Data = customerDto,
			StatusCode = StatusCodes.Status201Created,
			Message = "Add Successfully"
		};
	}



	[HttpGet("getcustomers/{pageNumber}/{pageSize}")]
	public async Task<ApiResponse<IEnumerable<CustomerDto>>> GetCustomers(int pageNumber, int pageSize = 15)
	{
		IEnumerable<CustomerDto> customerDtos = await _customerService.GetCustomersAsync(pageNumber, pageSize);

		return new ApiResponse<IEnumerable<CustomerDto>>
		{
			IsSuccess = true,
			Data = customerDtos,
			StatusCode = StatusCodes.Status200OK,
			Message = string.Empty
		};
	}



	[HttpGet("getcustomerbyid/{id}")]
	public async Task<ApiResponse<CustomerDto>> GetCustomerById(Guid id)
	{
		CustomerDto customerDto = await _customerService.GetCustomerByIdAsync(id);
		return new ApiResponse<CustomerDto>
		{
			IsSuccess = true,
			Data = customerDto,
			StatusCode = StatusCodes.Status200OK,
			Message = string.Empty
		};
	}


	[HttpDelete("deletecustomer/{id}")]
	public async Task<ApiResponse<CustomerDto>> DeleteCustomerById(Guid id)
	{
		CustomerDto customerDto = await _customerService.DeleteCustomerAsync(id);

		return new ApiResponse<CustomerDto>
		{
			IsSuccess = true,
			Data = customerDto,
			StatusCode = StatusCodes.Status204NoContent,
			Message = string.Empty
		};
	}



	[HttpGet("sortcustomersbyid/{pageNumber}/{pageSize}")]
	public async Task<ApiResponse<IEnumerable<CustomerDto>>> SortCustomersById(int pageNumber, int pageSize = 15)
	{
		IEnumerable<CustomerDto> customerDtos = await _customerService.SortCustomersById(pageNumber, pageSize);

		return new ApiResponse<IEnumerable<CustomerDto>>
		{
			IsSuccess = true,
			Data = customerDtos,
			StatusCode = StatusCodes.Status200OK,
			Message = string.Empty
		};
	}


	[HttpGet("searchforcustomer/{licenceNumber}")]
	public async Task<ApiResponse<CustomerDto>> SearchForCustomerrByLicenceNumber(string licenceNumber)
	{
		CustomerDto customerDto = await _customerService.SearchForCustomerByLicenceNumberAsync(licenceNumber);
		if (customerDto is not null)
		{
			return new ApiResponse<CustomerDto>
			{
				IsSuccess = true,
				Data = customerDto,
				StatusCode = StatusCodes.Status200OK,
				Message = string.Empty
			};
		}
		else
		{
			return new ApiResponse<CustomerDto>()
			{
				IsSuccess = false,
				Data = null,
				StatusCode = StatusCodes.Status404NotFound,
				Message = "there is no customer corresponds with the entered LicenceNumber"
			};
		}
	}

}
