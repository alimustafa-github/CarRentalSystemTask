namespace CarRental.Core.Entities;
public class Customer : IEntityBase
{
	public Guid Id { get; set; }
	public string UserId { get; set; }
	public virtual ApplicationUser User { get; set; }
	public bool HasLicence { get; set; }
	public string? LicenceNumber { get; set; }
	public DateTime? LicenseExpirationDate { get; set; }
	public DateTime JoinDate { get; set; }
	public Guid MembershipId { get; set; }
	public virtual Membership MembershipLevel { get; set; }
	public virtual ICollection<RentedCar> RentedCars { get; set; }
}
