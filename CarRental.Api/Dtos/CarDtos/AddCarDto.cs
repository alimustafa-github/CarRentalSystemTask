namespace CarRental.Api.Dtos.CarDtos;
public record AddCarDto
{
	public int SerialNumber { get; set; }

	public CarTypeDto Type { get; set; }
	public decimal DailyFaire { get; set; }

	public Color Color { get; set; }
	public decimal EngineCapacity { get; set; }

    public bool IsRented { get; set; }

    public DriverDto Driver { get; set; }
}
