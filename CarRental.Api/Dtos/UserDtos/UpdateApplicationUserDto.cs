namespace CarRental.Api.Dtos.UserDtos;

public record UpdateApplicationUserDto
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string PhoneNumber { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string CurrentAddress { get; set; }
	public bool IsCustomer { get; set; }
	public bool IsDriver { get; set; }
}
