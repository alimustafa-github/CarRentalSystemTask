using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;
[Route("api/car")]
[ApiController]
public class CarController : ControllerBase
{
	private readonly ICarService _carService;

	public CarController(ICarService carService)
	{
		_carService = carService;
	}

	[HttpGet("getcarsfromcache/{pagenumber}/{pagesize}")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> GetAllCarsFromCache(int pagenumber, int pagesize = 15)
	{
		IEnumerable<CarDto> carDtos = await _carService.GetCarsFromCacheAsync(pagenumber, pagesize);

		if (carDtos != null)
		{
			return new ApiResponse<IEnumerable<CarDto>>
			{
				StatusCode = StatusCodes.Status200OK,
				IsSuccess = true,
				Data = carDtos,
				Message = string.Empty
			};
		}
		else
		{
			throw new ArgumentNullException("no data has being retrieved");
		}
	}


	[HttpGet("getcars/{pagenumber}/{pagesize}")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> GetAllCarsFrom(int pagenumber, int pagesize = 15)
	{
		IEnumerable<CarDto> carDtos = await _carService.GetCarsAsync(pagenumber, pagesize);

		if (carDtos != null)
		{
			return new ApiResponse<IEnumerable<CarDto>>
			{
				StatusCode = StatusCodes.Status200OK,
				IsSuccess = true,
				Data = carDtos,
				Message = string.Empty
			};
		}
		else
		{
			throw new ArgumentNullException("no data has being retrieved");
		}
	}



	[HttpGet("searchcarbyid/{id}")]
	public async Task<ApiResponse<CarDto>> GetCarById(Guid id)
	{
		CarDto carDto = await _carService.GetCarByIdAsync(id);
		if (carDto != null)
		{
			return new ApiResponse<CarDto>
			{
				IsSuccess = true,
				Message = "Car Retrieved Successfully",
				StatusCode = StatusCodes.Status200OK,
				Data = carDto
			};
		}
		else
		{
			return new ApiResponse<CarDto>()
			{
				IsSuccess = false,
				StatusCode = StatusCodes.Status404NotFound,
				Data = null,
				Message = "There is no car corresponds with the given identifier"
			};
		}
	}

	[HttpPost("addcar")]
	public async Task<ApiResponse<CarDto>> AddCar([FromBody] AddCarDto addCarDto)
	{

		try
		{
			if (addCarDto != null)
			{
				CarDto carDto = await _carService.AddCarAsync(addCarDto);
				return new ApiResponse<CarDto>
				{
					IsSuccess = true,
					Data = carDto,
					StatusCode = StatusCodes.Status201Created,
					Message = "Car Added Successfully"
				};
			}
			else
			{
				return new ApiResponse<CarDto>
				{
					IsSuccess = false,
					Data = null,
					StatusCode = StatusCodes.Status400BadRequest,
					Message = "Could not Add the Car"
				};
			}
		}
		catch (Exception ex)
		{
			return new ApiResponse<CarDto>
			{
				IsSuccess = false,
				Data = null,
				Message = ex.Message
			};
		}
	}



	[HttpPut("updatecar/{id}")]
	public async Task<ApiResponse<CarDto>> UpdateCar(Guid id, [FromBody] UpdateCarDto updateCarDto)
	{
		if (!string.IsNullOrWhiteSpace(id.ToString()))
		{
			CarDto carDto = await _carService.UpdateCarAsync(id, updateCarDto);
			return new ApiResponse<CarDto>
			{
				IsSuccess = true,
				Data = carDto,
				StatusCode = StatusCodes.Status200OK,
				Message = "Car Updated Successfully"
			};
		}
		else
		{
			return new ApiResponse<CarDto>
			{
				IsSuccess = false,
				Data = null,
				StatusCode = StatusCodes.Status400BadRequest,
				Message = "Could not update the car"
			};
		}
	}


	[HttpDelete("deletecarbyid/{id}")]
	public async Task<ApiResponse<CarDto>> DeleteCar(object id)
	{

		try
		{
			if (!string.IsNullOrWhiteSpace(id.ToString()))
			{
				CarDto carDto = await _carService.DeleteCarAsync(id);
				if (carDto is not null)
				{
					return new ApiResponse<CarDto>
					{
						IsSuccess = true,
						Data = carDto,
						StatusCode = StatusCodes.Status204NoContent,
						Message = "Car Deleted Successfully"
					};
				}
				else
				{
					return new ApiResponse<CarDto>
					{
						IsSuccess = false,
						Data = null,
						Message = "there is no car corresponds to the entered identifier"
					};
				}

			}
			else
			{
				return new ApiResponse<CarDto>
				{
					IsSuccess = false,
					Data = null,
					Message = "Could not Delete the Car"
				};
			}
		}
		catch (Exception ex)
		{
			return new ApiResponse<CarDto>
			{
				IsSuccess = false,
				Data = null,
				Message = ex.Message
			};
		}
	}



	[HttpGet("sortcarsbyserialnumber/{pagenumber}/{pagesize}")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> SortTheCarsBySerialNumber(int pagenumber, int pagesize = 15)
	{
		IEnumerable<CarDto> carDtos = await _carService.SortCarsBySerialNumber(pagenumber, pagesize);

		return new ApiResponse<IEnumerable<CarDto>>
		{
			IsSuccess = true,
			Data = carDtos,
			StatusCode = StatusCodes.Status200OK,
			Message = string.Empty
		};
	}



	[HttpGet("searchbyserialnumber/{number}")]
	public async Task<ApiResponse<CarDto>> SearchBySerialNumber(int number)
	{
		CarDto carDto = await _carService.SearchForCarBySerialNumberAsync(number);
		if (carDto is null)
		{
			return new ApiResponse<CarDto>
			{
				IsSuccess = false,
				Data = null,
				StatusCode = StatusCodes.Status404NotFound,
				Message = "No car has been found"
			};
		}
		return new ApiResponse<CarDto>
		{
			IsSuccess = true,
			Data = carDto,
			StatusCode = StatusCodes.Status200OK,
			Message = string.Empty
		};
	}




	[HttpGet("filtercarsbyserialnumber/{number}")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> FilterTheCars(string number)
	{
		IEnumerable<CarDto> carDtos = await _carService.FilterTheCarsBySerialNumber(number);

		if (carDtos is not null && carDtos.ToList().Count > 0)
		{
			return new ApiResponse<IEnumerable<CarDto>>
			{
				IsSuccess = true,
				Data = carDtos,
				Message = string.Empty
			};
		}

		return new ApiResponse<IEnumerable<CarDto>>
		{
			IsSuccess = false,
			Data = Enumerable.Empty<CarDto>(),
			StatusCode = StatusCodes.Status404NotFound,
			Message = "No car has been found"
		};

	}


}
