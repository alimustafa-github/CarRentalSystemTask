namespace CarRental.Api.Controllers;
[Route("api/[controller]")]
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



	[HttpGet("getdrivers/{pageNumber}/{pageSize}")]
	public async Task<ApiResponse<IEnumerable<DriverDto>>> GetAllDrivers(int pageNumber, int pageSize = 15)
	{
		IEnumerable<DriverDto> driverDtos = await _driverService.GetDriversAsync(pageNumber, pageSize);

		return new ApiResponse<IEnumerable<DriverDto>>
		{
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
		DriverDto driverDto = await _driverService.DeleteDriverAsync(id);

		return new ApiResponse<DriverDto>
		{
			IsSuccess = true,
			Data = driverDto,
			StatusCode = StatusCodes.Status204NoContent,
			Message = string.Empty
		};
	}



	[HttpGet("sortdriversbyid/{pageNumber}/{pageSize}")]
	public async Task<ApiResponse<IEnumerable<DriverDto>>> SortDriversById(int pageNumber, int pageSize = 15)
	{
		IEnumerable<DriverDto> driverDtos = await _driverService.SortDriversById(pageNumber, pageSize);

		return new ApiResponse<IEnumerable<DriverDto>>
		{
			IsSuccess = true,
			Data = driverDtos,
			StatusCode = StatusCodes.Status200OK,
			Message = string.Empty
		};
	}


	[HttpGet("searchfordriver/{licenceNumber}")]
	public async Task<ApiResponse<DriverDto>> SearchForDriverByLicenceNumber(string licenceNumber)
	{
		DriverDto driverDto = await _driverService.SearchForDriverByLicenceNumberAsync(licenceNumber);
		if (driverDto is not null)
		{
			return new ApiResponse<DriverDto>
			{
				IsSuccess = true,
				Data = driverDto,
				StatusCode = StatusCodes.Status200OK
				Message = string.Empty
			};
		}
		else
		{
			return new ApiResponse<DriverDto>()
			{
				IsSuccess = false,
				Data = null,
				StatusCode = StatusCodes.Status404NotFound,
				Message = "there is no driver corresponds with the entered LicenceNumber"
			};
		}
	}



}
