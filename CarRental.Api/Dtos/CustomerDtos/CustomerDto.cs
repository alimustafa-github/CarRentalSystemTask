namespace CarRental.Api.Dtos.CustomerDtos;

public record CustomerDto
{
	public string Id { get; set; }
	public ApplicationUserDto User { get; set; }

	public bool HasLicence { get; set; }
	public string LicenceNumber { get; set; }
	public DateTime? LicenceExpirationDate { get; set; }
	public DateTime JoinDate { get; set; }
	public Guid MembershipId { get; set; }
	public int CurrentlyRentedCarsCount { get; set; }
	public ICollection<RentedCarDto> RentedCars { get; set; }


}
