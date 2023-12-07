namespace CarRental.Api.Dtos.CustomerDtos;

public record AddCustomerDto
{
	public RegistrationRequestDto User { get; set; }

	public bool HasLicence { get; set; }
	public string? LicenseNumber { get; set; }
	public DateTime? LicenseExpirationDate { get; set; }
	public DateTime JoinDate { get; set; }
	public Guid MembershipId { get; set; }

}
