namespace CarRental.Core.Entities;
public class RentedCar
{
    public Guid Id { get; set; }

    public Guid? DriverId { get; set; }
    public Driver? Driver { get; set; }

    public Guid CarId { get; set; }
    public Car Car { get; set; }
}
