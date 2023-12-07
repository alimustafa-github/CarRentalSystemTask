namespace CarRental.Api.Dtos.UserDtos;

public record RegistrationRequestDto
{
	public string Email { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string PhoneNumber { get; set; }
	public string UserName { get; set; }
	public string Password { get; set; }
	public string CurrentAddress { get; set; }
	public bool IsDriver { get; set; }
	public bool IsCustomer { get; set; }

}
