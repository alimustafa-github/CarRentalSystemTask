using CarRental.Api.Dtos.DriverDtos;
using CarRental.Core;

namespace CarRental.Api.Dtos.CarDtos;

public record UpdateCarDto
{
	public decimal DailyFaire { get; set; }
	public bool IsRented { get; set; }
	public DriverDto Driver { get; set; }
}
