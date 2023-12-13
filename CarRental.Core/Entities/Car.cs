namespace CarRental.Core.Entities;
public class Car : IEntityBase
{
	public Guid Id { get; set; }
	public int SerialNumber { get; set; }
	public Guid CarTypeId { get; set; }
	public virtual CarType CarType { get; set; }
	public decimal DailyFaire { get; set; }
	public Color Color { get; set; }
	public decimal EngineCapacity { get; set; }
	public bool IsRented { get; set; }
    public virtual RentedCar? RentalDetails { get; set; }
}
