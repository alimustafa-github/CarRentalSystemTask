namespace CarRental.Api.Controllers;
[Route("api/customer")]
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



	[HttpPost("getcustomerslist")]
	public async Task<ApiResponse<IEnumerable<CustomerDto>>> GetAllCustomers([FromBody] DataRequestDto input)
	{
		var result = await _customerService.GetCustomersAsync(input);
		IEnumerable<CustomerDto> customerDtos = result.Item1;
		int totalCount = result.Item2;

		return new ApiResponse<IEnumerable<CustomerDto>>
		{
			TotalCount = totalCount,
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
		await _customerService.DeleteCustomerAsync(id);

		return new ApiResponse<CustomerDto>
		{
			IsSuccess = true,
			Data = null,
			StatusCode = StatusCodes.Status204NoContent,
			Message = string.Empty
		};
	}






}
