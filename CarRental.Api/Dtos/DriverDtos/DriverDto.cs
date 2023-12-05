namespace CarRental.Api.Dtos.DriverDtos;

public record DriverDto
{
	public Guid Id { get; set; }
	public ApplicationUserDto User { get; set; }
	public int TotalRentalCount { get; set; }
	public DateTime JoinDate { get; set; }
	public DateTime ContractEndDate { get; set; }
	public string LicenceNumber { get; set; }
	public DateTime LicenseExpirationDate { get; set; }
	public bool IsAvailable { get; set; }
	public AlternativeDriverDto AlternativeDriver { get; set; }
}
