using CarRental.Api.Dtos.CarDtos;

namespace CarRental.Api.Dtos;

public class RentedCarDto
{
	public Guid Id { get; set; }

	public Guid? DriverId { get; set; }
	public DriverDto? Driver { get; set; }

	public Guid CarId { get; set; }
	public AddCarDto Car { get; set; }
}
