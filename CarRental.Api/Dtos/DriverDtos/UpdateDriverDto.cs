namespace CarRental.Api.Dtos.DriverDtos;

public record UpdateDriverDto
{
	public DateTime JoinDate { get; set; }
	public DateTime ContractEndDate { get; set; }
	public string LicenceNumber { get; set; }
	public DateTime LicenseExpirationDate { get; set; }
	public AlternativeDriverDto AlternativeDriver { get; set; }
	public CarDto Car { get; set; }
}
