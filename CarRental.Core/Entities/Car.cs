namespace CarRental.Core.Entities;
public class Car
{
	public Guid Id { get; set; }
    public int SerialNumber { get; set; }

    public string Type { get; set; }
    public decimal DailyFaire { get; set; }

    public Color Color { get; set; }
    public decimal EngineCapacity { get; set; }
    public bool WithDriver { get; set; }

}
