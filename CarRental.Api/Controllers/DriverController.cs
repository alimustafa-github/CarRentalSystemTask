using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
		try
		{
			DriverDto driverDto = await _driverService.AddDriverAsync(addDriverDto);
			if (driverDto is not null)
			{
				return new ApiResponse<DriverDto>
				{
					IsSuccess = true,
					Data = driverDto,
					Message = "Add Successfully"
				};
			}
			else
			{
				return new ApiResponse<DriverDto>
				{
					IsSuccess = false,
					Data = null,
					Message = "failed"
				};
			}
		}
		catch (Exception ex)
		{

			return new ApiResponse<DriverDto>
			{
				IsSuccess = false,
				Data = null,
				Message = "Exception happened"
			};
		}
	}



	[HttpGet("getdrivers/{pageNumber}/{pageSize}")]
	public async Task<ApiResponse<IEnumerable<DriverDto>>> GetAllDrivers(int pageNumber, int pageSize = 15)
	{
		try
		{
			IEnumerable<DriverDto> driverDtos = await _driverService.GetDriversAsync(pageNumber, pageSize);

			if (driverDtos is not null)
			{
				return new ApiResponse<IEnumerable<DriverDto>>
				{
					IsSuccess = true,
					Data = driverDtos,
					Message =string.Empty
				};
			}
			else
			{
				return new ApiResponse<IEnumerable<DriverDto>>
				{
					IsSuccess = true,
					Data = null,
					Message = "We do not have any drivers yet"
				};
			}
		}
		catch (Exception ex)
		{
			return new ApiResponse<IEnumerable<DriverDto>>
			{
				IsSuccess = false,
				Data = Enumerable.Empty<DriverDto>(),
				Message = ex.Message
			};
		}
	}



	[HttpGet("getdriverbyid/{id}")]
	public async Task<ApiResponse<DriverDto>> GetDriverById(Guid id)
	{
		try
		{
			DriverDto driverDto = await _driverService.GetDriverByIdAsync(id);
			if (driverDto is not null)
			{
				return new ApiResponse<DriverDto>
				{
					IsSuccess = true,
					Data = driverDto,
					Message = string.Empty
				};
			}
			else
			{
				return new ApiResponse<DriverDto>()
				{
					IsSuccess = false,
					Data = null,
					Message = "there is no driver corresponds with the entered Id"
				};
			}

		}
		catch (Exception ex)
		{
			return new ApiResponse<DriverDto>()
			{
				IsSuccess = false,
				Data = null,
				Message = ex.Message
			};
		}
	}


	[HttpDelete("deletedriver/{id}")]
	public async Task<ApiResponse<DriverDto>> DeleteDriverById(Guid id)
	{

		try
		{
			DriverDto driverDto = await _driverService.DeleteDriverAsync(id);

			if (driverDto is not null)
			{
				return new ApiResponse<DriverDto>
				{
					IsSuccess = true,
					Data = driverDto,
					Message = "Deleted Successfully"
				};
			}
			else
			{
				return new ApiResponse<DriverDto>()
				{
					IsSuccess = false,
					Data = null,
					Message = "there is no driver corresponds with the entered Id"
				};
			}

		}
		catch (Exception ex)
		{
			return new ApiResponse<DriverDto>()
			{
				IsSuccess = false,
				Data = null,
				Message = ex.Message
			};
		}
	}



	[HttpGet("sortdriversbyid/{pageNumber}/{pageSize}")]
	public async Task<ApiResponse<IEnumerable<DriverDto>>> SortDriversById(int pageNumber, int pageSize = 15)
	{
		try
		{
			IEnumerable<DriverDto> driverDtos = await _driverService.SortDriversById(pageNumber, pageSize);

			if (driverDtos is not null)
			{
				return new ApiResponse<IEnumerable<DriverDto>>
				{
					IsSuccess = true,
					Data = driverDtos,
					Message = string.Empty
				};
			}
			else
			{
				return new ApiResponse<IEnumerable<DriverDto>>
				{
					IsSuccess = true,
					Data = null,
					Message = "We do not have any drivers yet"
				};
			}
		}
		catch (Exception ex)
		{
			return new ApiResponse<IEnumerable<DriverDto>>
			{
				IsSuccess = false,
				Data = Enumerable.Empty<DriverDto>(),
				Message = ex.Message
			};
		}
	}


	[HttpGet("searchfordriver/{licenceNumber}")]
	public async Task<ApiResponse<DriverDto>> SearchForDriverByLicenceNumber(string licenceNumber)
	{
		try
		{
			DriverDto driverDto = await _driverService.SearchForDriverByLicenceNumberAsync(licenceNumber);
			if (driverDto is not null)
			{
				return new ApiResponse<DriverDto>
				{
					IsSuccess = true,
					Data = driverDto,
					Message = string.Empty
				};
			}
			else
			{
				return new ApiResponse<DriverDto>()
				{
					IsSuccess = false,
					Data = null,
					Message = "there is no driver corresponds with the entered LicenceNumber"
				};
			}

		}
		catch (Exception ex)
		{
			return new ApiResponse<DriverDto>()
			{
				IsSuccess = false,
				Data = null,
				Message = ex.Message
			};
		}
	}



}
