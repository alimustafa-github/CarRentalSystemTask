using CarRental.Core;

namespace CarRental.Api.Dtos.CarDtos;

public record UpdateCarDto
{
	public decimal DailyFaire { get; set; }
    public bool IsRented { get; set; }
}
