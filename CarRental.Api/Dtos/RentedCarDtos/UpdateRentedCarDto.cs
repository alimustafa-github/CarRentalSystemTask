namespace CarRental.Api.Dtos.RentedCarDtos;

public record UpdateRentedCarDto
{
	public Guid? DriverId { get; set; }
	public Guid? CarId { get; set; }
	public Guid? CustomerId { get; set; }
	public DateTime? ReservationStartDate { get; set; }
	public DateTime? ReservationEndDate { get; set; }
}
