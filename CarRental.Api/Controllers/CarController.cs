namespace CarRental.Api.Controllers;
[Route("api/car")]
[ApiController]
public class CarController : ControllerBase
{
	private readonly ICarService _carService;
	private readonly IMapper _mapper;

	public CarController(ICarService carService, IMapper mapper)
	{
		_carService = carService;
		_mapper = mapper;
	}





	[HttpGet("searchcarbyid/{id}")]
	public async Task<ApiResponse<CarDto>> GetCarById(Guid id)
	{
		CarDto carDto = await _carService.GetCarByIdAsync(id);
		return new ApiResponse<CarDto>
		{
			IsSuccess = true,
			Message = "Car Retrieved Successfully",
			StatusCode = StatusCodes.Status200OK,
			Data = carDto
		};
	}

	[HttpPost("addcar")]
	public async Task<ApiResponse<CarDto>> AddCar([FromBody] AddCarDto addCarDto)
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



	[HttpPut("updatecar/{id}")]
	public async Task<ApiResponse<CarDto>> UpdateCar(Guid id, [FromBody] UpdateCarDto updateCarDto)
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


	[HttpDelete("deletecarbyid/{id}")]
	public async Task<ApiResponse<CarDto>> DeleteCar(object id)
	{
		await _carService.DeleteCarAsync(id);
		return new ApiResponse<CarDto>
		{
			IsSuccess = true,
			Data = null,
			StatusCode = StatusCodes.Status204NoContent,
			Message = "Car Deleted Successfully"
		};
	}




	[HttpPost("getcarslist")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> GetCars([FromBody] DataRequestDto input)
	{
		var result = await _carService.GetCarsAsync(input);
		IEnumerable<CarDto> carDtos = result.Item1;
		int Count = result.Item2;


		return new ApiResponse<IEnumerable<CarDto>>
		{
			TotalCount = Count,
			IsSuccess = true,
			Message = string.Empty,
			Data = carDtos,
			StatusCode = StatusCodes.Status200OK
		};
	}
}
