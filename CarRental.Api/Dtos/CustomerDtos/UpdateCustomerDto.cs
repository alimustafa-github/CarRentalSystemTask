namespace CarRental.Api.Dtos.CustomerDtos;

public record UpdateCustomerDto
{
	public UpdateUserDto User { get; set; }
	public bool HasLicence { get; set; }
	public string? EmergencyContactName { get; set; }
	public string? EmergencyContactNumber { get; set; }
	public MembershipDto MembershipLevel { get; set; }
	public string LicenseNumber { get; set; }
	public DateTime? LicenseExpirationDate { get; set; }
}
