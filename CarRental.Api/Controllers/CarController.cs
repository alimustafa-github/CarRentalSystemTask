using CarRental.Api.Dtos;
using CarRental.Api.Services;
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

	[HttpGet("getcars/{pagenumber}/{pagesize}")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> GetAllCars(int pageNumber, int pagesize=15)
	{
		try
		{
			IEnumerable<CarDto> carDtos = await _carService.GetCarsAsync(pageNumber, pagesize);	

			if (carDtos != null)
			{
				return new ApiResponse<IEnumerable<CarDto>>
				{
					IsSuccess = true,
					Data = carDtos,
					Message = string.Empty
				};
			}
			else
			{
				return new ApiResponse<IEnumerable<CarDto>>
				{
					IsSuccess = true,
					Data = null,
					Message = "We do not have any cars"
				};
			}
		}
		catch (Exception ex)
		{
			return new ApiResponse<IEnumerable<CarDto>>
			{
				IsSuccess = false,
				Data = Enumerable.Empty<CarDto>(),
				Message = ex.Message
			};
		}
	}



	[HttpGet("searchcarbyid/{id}")]
	public async Task<ApiResponse<CarDto>> GetCarById(Guid id)
	{
		try
		{
			CarDto carDto = await _carService.GetCarByIdAsync(id);
			if (carDto != null)
			{
				return new ApiResponse<CarDto>
				{
					IsSuccess = true,
					Data = carDto
				};
			}
			else
			{
				return new ApiResponse<CarDto>()
				{
					IsSuccess = false,
					Data = null,
					Message = "you have entered an invalid identifier"
				};
			}

		}
		catch (Exception ex)
		{
			return new ApiResponse<CarDto>()
			{
				IsSuccess = false,
				Data = null,
				Message = ex.Message
			};
		}
	}





	[HttpPost("addcar")]
	public async Task<ApiResponse<CarDto>> AddCar([FromBody] CarDto carDto)
	{

		try
		{
			if (carDto != null)
			{
				carDto = await _carService.AddCarAsync(carDto);
				return new ApiResponse<CarDto>
				{
					IsSuccess = true,
					Data = carDto,
					Message = "Car Added Successfully"
				};
			}
			else
			{
				return new ApiResponse<CarDto>
				{
					IsSuccess = false,
					Data = null,
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



	[HttpPut("updatecar")]
	public async Task<ApiResponse<CarDto>> updateCar([FromBody] CarDto carDto)
	{

		try
		{
			if (carDto != null)
			{
				carDto = await _carService.UpdateCarAsync(carDto);
				return new ApiResponse<CarDto>
				{
					IsSuccess = true,
					Data = carDto,
					Message = "Car Updated Successfully"
				};
			}
			else
			{
				return new ApiResponse<CarDto>
				{
					IsSuccess = false,
					Data = null,
					Message = "Could not update the car"
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


	[HttpDelete("deletecarbyid/{id}")]
	public async Task<ApiResponse<CarDto>> DeleteCar(Guid id)
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
		try
		{
			IEnumerable<CarDto> carDtos = await _carService.SortCarsBySerialNumber(pagenumber, pagesize);	
			if (carDtos != null)
			{

				return new ApiResponse<IEnumerable<CarDto>>
				{
					IsSuccess = true,
					Data = carDtos,
					Message = string.Empty
				};
			}
			else
			{

				return new ApiResponse<IEnumerable<CarDto>>
				{
					IsSuccess = false,
					Data = null,
					Message = "We do not have any cars in out system"
				};
			}
		}
		catch (Exception ex)
		{

			return new ApiResponse<IEnumerable<CarDto>>
			{
				IsSuccess = false,
				Data = Enumerable.Empty<CarDto>(),
				Message = ex.Message
			};
		}
	}



	[HttpGet("searchbyserialnumber/{number}")]
	public async Task<ApiResponse<CarDto>> SearchBySerialNumber(int number)
	{
		try
		{
			CarDto carDto = await _carService.SearchForCarBySerialNumberAsync(number);

			if (carDto is not null)
			{
				return new ApiResponse<CarDto>
				{
					IsSuccess = true,
					Data = carDto,
					Message = string.Empty
				};
			}
			else
			{
				return new ApiResponse<CarDto>
				{
					IsSuccess = false,
					Data = null,
					Message = "Could not find the car"
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



}
