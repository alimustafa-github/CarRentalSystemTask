namespace CarRental.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RentedCarController : ControllerBase
{
	private readonly IRentedCarService _rentedCarService;

	public RentedCarController(IRentedCarService rentedCarService)
	{
		_rentedCarService = rentedCarService;
	}


	[HttpPost("getrentedcarslist")]
	public async Task<ApiResponse<IEnumerable<RentedCarDto>>> GetAllRentedCars([FromBody] DataRequestDto input)
	{
		var result = await _rentedCarService.GetRentedCarsAsync(input);
		IEnumerable<RentedCarDto> rentedCarDtos = result.Item1;
		int totalCount = result.Item2;

		return new ApiResponse<IEnumerable<RentedCarDto>>
		{
			TotalCount = totalCount,
			IsSuccess = true,
			Data = rentedCarDtos,
			StatusCode = StatusCodes.Status200OK,
			Message = string.Empty
		};
	}




	[HttpGet("searchforrentedcarbyid/{id}")]
	public async Task<ApiResponse<RentedCarDto>> GetRentedCarById(Guid id)
	{
		RentedCarDto rentedCarDto = await _rentedCarService.GetRentedCarByIdAsync(id);
		return new ApiResponse<RentedCarDto>
		{
			IsSuccess = true,
			Message = "Car Retrieved Successfully",
			StatusCode = StatusCodes.Status200OK,
			Data = rentedCarDto
		};
	}

	[HttpPost("addrentedcar")]
	public async Task<ApiResponse<RentedCarDto>> AddCar([FromBody] AddRentedCarDto addRentedCarDto)
	{
		RentedCarDto rentedCarDto = await _rentedCarService.AddRentedCarAsync(addRentedCarDto);
		return new ApiResponse<RentedCarDto>
		{
			IsSuccess = true,
			Data = rentedCarDto,
			StatusCode = StatusCodes.Status201Created,
			Message = "Car Added Successfully"
		};
	}



	[HttpPut("updaterentedcar/{id}")]
	public async Task<ApiResponse<RentedCarDto>> UpdateRentedCar(Guid id, [FromBody] UpdateRentedCarDto updateCarDto)
	{
		RentedCarDto rentedCarDto = await _rentedCarService.UpdateRentedCarAsync(id, updateCarDto);
		return new ApiResponse<RentedCarDto>
		{
			IsSuccess = true,
			Data = rentedCarDto,
			StatusCode = StatusCodes.Status200OK,
			Message = "Car Updated Successfully"
		};
	}


	[HttpDelete("deleterentedcarbyid/{id}")]
	public async Task<ApiResponse<RentedCarDto>> DeleteRentedCar(Guid id)
	{
		await _rentedCarService.DeleteRentedCarByIdAsync(id);
		return new ApiResponse<RentedCarDto>
		{
			IsSuccess = true,
			Data = null,
			StatusCode = StatusCodes.Status204NoContent,
			Message = "Car Deleted Successfully"
		};
	}


}
