namespace CarRental.Core.Entities;
public class Driver : IEntityBase
{
	public Guid Id { get; set; }
	public string UserId { get; set; }
	public ApplicationUser User { get; set; }
	public int TotalRentalCount { get; set; }
	public DateTime JoinDate { get; set; }
	public DateTime ContractEndDate { get; set; }
	public string LicenceNumber { get; set; }
	public DateTime LicenseExpirationDate { get; set; }
	public Guid ContractNumber { get; set; }
	public bool IsBusy { get; set; }
}
