namespace CarRental.Api.Dtos.CustomerDtos;

public record CustomerDto
{
	public string Id { get; set; }
	public ApplicationUserDto User { get; set; }

	public bool HasLicence { get; set; }
	public string LicenseNumber { get; set; }
	public DateTime? LicenseExpirationDate { get; set; }
	public DateTime JoinDate { get; set; }
	public string? EmergencyContactName { get; set; }
	public string? EmergencyContactNumber { get; set; }
	public MembershipDto MembershipLevel { get; set; }
	public int CurrentlyRentedCarsCount { get; set; }
	public ICollection<RentedCarDto> RentedCars { get; set; }


}
