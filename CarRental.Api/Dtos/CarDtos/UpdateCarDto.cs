namespace CarRental.Api.Dtos.CarDtos;

public record UpdateCarDto
{
	public decimal DailyFaire { get; set; }
	public bool IsRented { get; set; }
	public Guid DriverId { get; set; }
}
