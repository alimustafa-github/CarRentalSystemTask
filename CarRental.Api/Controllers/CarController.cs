using CarRental.Core.Dtos;
using CarRental.Core.Entities;
using CarRental.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;
[Route("api/car")]
[ApiController]
public class CarController : ControllerBase
{
	/// <summary>
	/// I have used the unit of work to get to the cars methods 
	/// I usually do it by create an interface like ICarService inside the Api project and then initialize by dependency injection and use it here
	/// but I did it this way to simplify it as possible
	/// </summary>
	private readonly IUnitOfWork<Car> _carUnit;

	public CarController(IUnitOfWork<Car> carUnit)
	{
		_carUnit = carUnit;
	}


	[HttpGet("getallcars")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> GetAllCars()
	{
		try
		{
			IEnumerable<Car> cars = await _carUnit.Entity.GetAllAsync();
			IEnumerable<CarDto> carDtos = cars.ConvertToCarDto();

			if (carDtos != null)
			{
				return new ApiResponse<IEnumerable<CarDto>>(true, carDtos);
			}
			else
			{
				return new ApiResponse<IEnumerable<CarDto>>(true, Enumerable.Empty<CarDto>(), "We do not currently have any cars in our system");
			}
		}
		catch (Exception ex)
		{
			return new ApiResponse<IEnumerable<CarDto>>(false, Enumerable.Empty<CarDto>(), ex.Message);
		}
	}


	[HttpGet("getallcarsfromcache")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> GetAllCarsFromCache()
	{
		try
		{
			IEnumerable<Car> cars = await _carUnit.Entity.GetAllFromCache();
			IEnumerable<CarDto> carDtos = cars.ConvertToCarDto();

			if (carDtos != null)
			{
				return new ApiResponse<IEnumerable<CarDto>>(true, carDtos);
			}
			else
			{
				return new ApiResponse<IEnumerable<CarDto>>(true, Enumerable.Empty<CarDto>(), "We do not currently have any cars in our system");
			}
		}
		catch (Exception ex)
		{
			return new ApiResponse<IEnumerable<CarDto>>(false, Enumerable.Empty<CarDto>(), ex.Message);
		}
	}



	[HttpGet("searchcarbyid/{id}")]
	public async Task<ApiResponse<CarDto>> GetCarById(Guid id)
	{
		try
		{
			Car car = await _carUnit.Entity.GetByIdAsync(id);
			if (car != null)
			{
				CarDto carDto = car.ConvertToCarDto();

				if (carDto != null)
				{
					return new ApiResponse<CarDto>(true, carDto);
				}
				else
				{
					return new ApiResponse<CarDto>(false, null, "Could not find the car");
				}

			}
			else
			{
				return new ApiResponse<CarDto>(false, null, "you have entered an invalid identifier");

			}

		}
		catch (Exception ex)
		{
			return new ApiResponse<CarDto>(false, null, ex.Message);
		}
	}





	[HttpPost("addcar")]
	public async Task<ApiResponse> AddCar([FromBody] CarDto carDto)
	{

		try
		{
			if (carDto!=null)
			{
				Car car = carDto.ConvertToCar();
				await _carUnit.Entity.AddAsync(car);
				await _carUnit.Save();

				return new ApiResponse(true, "Car Added Successfully");
			}
			else
			{
				return new ApiResponse(false, "Could not insert the Car");

			}
		}
		catch (Exception ex)
		{
			return new ApiResponse(false, ex.Message);
		}
	}



	[HttpPut("updatecar")]
	public async Task<ApiResponse> updateCar( [FromBody] CarDto carDto)
	{

		try
		{
			if (carDto != null)
			{
				Car car = carDto.ConvertToCar();
			    _carUnit.Entity.Update(car);
				await _carUnit.Save();

				return new ApiResponse(true, "Car Updated Successfully");
			}
			else
			{
				return new ApiResponse(false, "Could not Update the Car");

			}
		}
		catch (Exception ex)
		{
			return new ApiResponse(false, ex.Message);
		}
	}


	[HttpDelete("deletecarbyid/{id}")]
	public async Task<ApiResponse> DeleteCar(Guid id)
	{

		try
		{
			if (!string.IsNullOrWhiteSpace(id.ToString()))
			{
				await _carUnit.Entity.DeleteAsync(id);
				await _carUnit.Save();

				return new ApiResponse(true, "Car Deleted Successfully");
			}
			else
			{
				return new ApiResponse(false, "Invalid Id");

			}
		}
		catch (Exception ex)
		{
			return new ApiResponse(false, ex.Message);
		}
	}



	[HttpGet("sortcarsbyserialnumber")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> SortTheCarsBySerialNumber()
	{
		try
		{
			IEnumerable<Car> cars =await _carUnit.Entity.SortAsync(car => car.SerialNumber);
			IEnumerable<CarDto> carDtos = cars.ConvertToCarDto();

			if (carDtos != null)
			{
				return new ApiResponse<IEnumerable<CarDto>>(true, carDtos);
			}
			else
			{
				return new ApiResponse<IEnumerable<CarDto>>(true, Enumerable.Empty<CarDto>(), "We do not currently have any cars in our system");
			}
		}
		catch (Exception ex)
		{
			return new ApiResponse<IEnumerable<CarDto>>(false, Enumerable.Empty<CarDto>(), ex.Message);
		}
	}

	[HttpGet("sortcarsbyidentifier")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> SortTheCarsById()
	{
		try
		{
			IEnumerable<Car> cars = await _carUnit.Entity.SortAsync(car => car.Id);
			IEnumerable<CarDto> carDtos = cars.ConvertToCarDto();

			if (carDtos != null)
			{
				return new ApiResponse<IEnumerable<CarDto>>(true, carDtos);
			}
			else
			{
				return new ApiResponse<IEnumerable<CarDto>>(true, Enumerable.Empty<CarDto>(), "We do not currently have any cars in our system");
			}
		}
		catch (Exception ex)
		{
			return new ApiResponse<IEnumerable<CarDto>>(false, Enumerable.Empty<CarDto>(), ex.Message);
		}
	}

	/// <summary>
	/// this method will get that all the cars that their serial number starts with provided prefix
	/// </summary>
	/// <param name="prefix">the prefix which the serial number starts with</param>
	/// <returns></returns>

	[HttpGet("getcarsbasedonserialnumber/{prefix}")]
	public async Task<ApiResponse<IEnumerable<CarDto>>> GetCarsBasedOnSerialNumber(string prefix)
	{
		try
		{
			string propertyName = "SerialNumber";


			var items = await _carUnit.Entity.GetItemsByPropertyPrefix(propertyName, prefix);
			if (items is not null)
			{
				return new ApiResponse<IEnumerable<CarDto>>(true, items.ConvertToCarDto());

			}
			else
			{
				return new ApiResponse<IEnumerable<CarDto>>(false, Enumerable.Empty<CarDto>(), $"We do not have any cars in our systems which the serial number starts with {prefix}");

			}
		}
		catch (Exception ex)	
		{
			return new ApiResponse<IEnumerable<CarDto>>(false, Enumerable.Empty<CarDto>(), ex.Message);
		}
	}




}
