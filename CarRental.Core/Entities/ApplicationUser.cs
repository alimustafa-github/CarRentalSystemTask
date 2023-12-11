using Microsoft.VisualBasic;

namespace CarRental.Core.Entities;
public class ApplicationUser : IdentityUser
{
	
	public string FirstName { get; set; }
	public string? LastName { get; set; }
    public Driver Driver { get; set; }
    public Customer Customer { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? CurrentAddress { get; set; }
    public bool IsCustomer { get; set; }
    public bool IsDriver { get; set; }
	public string? EmergencyContactName { get; set; }
	public string? EmergencyContactNumber { get; set; }
}
