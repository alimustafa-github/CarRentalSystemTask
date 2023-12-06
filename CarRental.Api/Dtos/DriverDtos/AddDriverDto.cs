namespace CarRental.Api.Dtos.DriverDtos;

public record AddDriverDto
{
	public RegistrationRequestDto User { get; set; }
	public DateTime JoinDate { get; set; }
	public DateTime ContractEndDate { get; set; }
	public string LicenceNumber { get; set; }
	public DateTime LicenseExpirationDate { get; set; }
	public bool IsAvailable { get; set; }
	public Guid? AlternativeDriverId { get; set; }
}
