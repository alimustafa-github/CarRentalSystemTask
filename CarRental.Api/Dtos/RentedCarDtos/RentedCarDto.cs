namespace CarRental.Api.Dtos.RentedCarDtos;

public record RentedCarDto
{
	public Guid Id { get; set; }
	public DriverDto? Driver { get; set; }
	public CarDto Car { get; set; }
	public CustomerDto Customer { get; set; }
	public DateTime ReservationStartDate { get; set; }
	public DateTime ReservationEndDate { get; set; }
}
