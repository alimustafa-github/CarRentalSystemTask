namespace CarRental.Core.Entities;
public class Car : IEntityBase
{
	public Guid Id { get; set; }
	public int SerialNumber { get; set; }

	public Guid CarTypeId { get; set; }
	public CarType CarType { get; set; }

	public decimal DailyFaire { get; set; }

	public Color Color { get; set; }
	public decimal EngineCapacity { get; set; }

}
