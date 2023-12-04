using CarRental.Api.Dtos.MembershipDtos;
using CarRental.Api.Dtos.UserDtos;

namespace CarRental.Api.Dtos.CustomerDtos;

public record UpdateCustomerDto
{
	public UpdateUserDto UserDto { get; set; }
	public bool HasLicence { get; set; }
	public string LicenseNumber { get; set; }
	public DateTime? LicenseExpirationDate { get; set; }
	public DateTime JoinDate { get; set; }
	public string? EmergencyContactName { get; set; }
	public string? EmergencyContactNumber { get; set; }
	public MembershipDto Membership { get; set; }
	public int CurrentlyRentedCarsCount { get; set; }

	public int TotalRentalHistoryCount { get; set; }
	public IEnumerable<RentedCarDto> RentedCars { get; set; }

}
