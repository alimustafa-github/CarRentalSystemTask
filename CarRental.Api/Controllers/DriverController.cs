namespace CarRental.Api.Controllers;
[Route("api/driver")]
[ApiController]
public class DriverController : ControllerBase
{
	private readonly IDriverService _driverService;

	public DriverController(IDriverService driverService)
	{
		_driverService = driverService;
	}


	[HttpPost("adddriver")]
	public async Task<ApiResponse<DriverDto>> AddDriver([FromBody] AddDriverDto addDriverDto)
	{
		DriverDto driverDto = await _driverService.AddDriverAsync(addDriverDto);
		return new ApiResponse<DriverDto>
		{
			IsSuccess = true,
			Data = driverDto,
			StatusCode = StatusCodes.Status201Created,
			Message = "Add Successfully"
		};
	}



	[HttpPost("getdriverslist")]
	public async Task<ApiResponse<IEnumerable<DriverDto>>> GetAllDrivers([FromBody] DataRequestDto driverRequestDto)
	{
		var result = await _driverService.GetDriversAsync(driverRequestDto);
		IEnumerable<DriverDto> driverDtos = result.Item1;
		int totalCount = result.Item2;

		return new ApiResponse<IEnumerable<DriverDto>>
		{
			TotalCount = totalCount,
			IsSuccess = true,
			Data = driverDtos,
			StatusCode = StatusCodes.Status200OK,
			Message = string.Empty
		};
	}





	[HttpGet("getdriverbyid/{id}")]
	public async Task<ApiResponse<DriverDto>> GetDriverById(Guid id)
	{
		DriverDto driverDto = await _driverService.GetDriverByIdAsync(id);
		return new ApiResponse<DriverDto>
		{
			IsSuccess = true,
			Data = driverDto,
			StatusCode = StatusCodes.Status200OK,
			Message = string.Empty
		};
	}


	[HttpDelete("deletedriver/{id}")]
	public async Task<ApiResponse<DriverDto>> DeleteDriverById(Guid id)
	{
	       await _driverService.DeleteDriverAsync(id);

		return new ApiResponse<DriverDto>
		{
			IsSuccess = true,
			Data = null,
			StatusCode = StatusCodes.Status204NoContent,
			Message = string.Empty
		};
	}





}
