namespace CarRental.Core.Entities;
public class RentedCar : IEntityBase
{
    public Guid Id { get; set; }
    public Guid? DriverId { get; set; }
    public Driver? Driver { get; set; }
    public Guid CarId { get; set; }
    public Car Car { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime ReservationStartDate { get; set; }
    public DateTime ReservationEndDate { get; set; }


}
