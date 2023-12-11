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
		CarDto carDto = await _carService.DeleteCarAsync(id);
		return new ApiResponse<CarDto>
		{
			IsSuccess = true,
			Data = carDto,
			StatusCode = StatusCodes.Status204NoContent,
			Message = "Car Deleted Successfully"
		};
	}




	[HttpPost("getcarslist")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> GetCarsWithSortingAndPagination([FromBody] CarRequestDto input)
	{
		var result = await _carService.GetCarsWithSortingAndFiltering(input);
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

	//[HttpGet("sortcarsbyserialnumber/{pagenumber}/{pagesize}")]
	//public async Task<ApiResponse<IEnumerable<CarDto>>> SortTheCarsBySerialNumber(int pagenumber, int pagesize = 15)
	//{
	//	IEnumerable<CarDto> carDtos = await _carService.SortCarsBySerialNumber(pagenumber, pagesize);

	//	return new ApiResponse<IEnumerable<CarDto>>
	//	{
	//		IsSuccess = true,
	//		Data = carDtos,
	//		StatusCode = StatusCodes.Status200OK,
	//		Message = string.Empty
	//	};
	//}



	//[HttpGet("searchbyserialnumber/{number}")]
	//public async Task<ApiResponse<CarDto>> SearchBySerialNumber(int number)
	//{
	//	CarDto carDto = await _carService.SearchForCarBySerialNumberAsync(number);
	//	if (carDto is null)
	//	{
	//		return new ApiResponse<CarDto>
	//		{
	//			IsSuccess = false,
	//			Data = null,
	//			StatusCode = StatusCodes.Status404NotFound,
	//			Message = "No car has been found"
	//		};
	//	}
	//	return new ApiResponse<CarDto>
	//	{
	//		IsSuccess = true,
	//		Data = carDto,
	//		StatusCode = StatusCodes.Status200OK,
	//		Message = string.Empty
	//	};
	//}




	//[HttpGet("filtercarsbyserialnumber/{number}")]
	//public async Task<ApiResponse<IEnumerable<CarDto>>> FilterTheCars(string number)
	//{
	//	IEnumerable<CarDto> carDtos = await _carService.FilterTheCarsBySerialNumber(number);

	//	if (carDtos is not null && carDtos.ToList().Count > 0)
	//	{
	//		return new ApiResponse<IEnumerable<CarDto>>
	//		{
	//			IsSuccess = true,
	//			Data = carDtos,
	//			Message = string.Empty
	//		};
	//	}

	//	return new ApiResponse<IEnumerable<CarDto>>
	//	{
	//		IsSuccess = false,
	//		Data = Enumerable.Empty<CarDto>(),
	//		StatusCode = StatusCodes.Status404NotFound,
	//		Message = "No car has been found"
	//	};

	//}


}
