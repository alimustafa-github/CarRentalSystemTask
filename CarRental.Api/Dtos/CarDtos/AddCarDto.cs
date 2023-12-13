namespace CarRental.Api.Dtos.CarDtos;
public record AddCarDto
{
	public int SerialNumber { get; set; }

	public Guid CarTypeId { get; set; }
	public decimal DailyFaire { get; set; }

	public Color Color { get; set; }
	public decimal EngineCapacity { get; set; }

    public bool IsRented { get; set; }

}
