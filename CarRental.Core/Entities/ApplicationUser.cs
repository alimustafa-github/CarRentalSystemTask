using Microsoft.AspNetCore.Identity;

namespace CarRental.Core.Entities;
public class ApplicationUser : IdentityUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
    public Driver Driver { get; set; }
    public Customer Customer { get; set; }
    public DateTime DateOfBirth { get; set; }
	public string CurrentAddress { get; set; }

}
