namespace CarRental.Api.Dtos.RentedCarDtos;

public record UpdateRentedCarDto
{
	public DriverDto? Driver { get; set; }
	public CarDto Car { get; set; }
	public CustomerDto Customer { get; set; }
	public DateTime ReservationStartDate { get; set; }
	public DateTime ReservationEndDate { get; set; }
}
