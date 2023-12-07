namespace CarRental.Core.Entities;
public class Customer : IEntityBase
{
	public Guid Id { get; set; }
	public string UserId { get; set; }
	public ApplicationUser User { get; set; }
	public bool HasLicence { get; set; }
	public string? LicenseNumber { get; set; }
	public DateTime? LicenseExpirationDate { get; set; }
	public DateTime JoinDate { get; set; }
	public Guid MembershipId { get; set; }
	public Membership MembershipLevel { get; set; }
	public ICollection<RentedCar> RentedCars { get; set; }
}
