namespace CarRental.Api.Services;

public class CarRentedEvent : INotification
{
	public Guid CarId { get; set; }
    public Guid DriverId { get; set; }
    public bool Cancellation { get; set; } = false;
}
