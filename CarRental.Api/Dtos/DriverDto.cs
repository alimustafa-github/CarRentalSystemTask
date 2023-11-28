namespace CarRental.Api.Dtos;

public class DriverDto
{
	public Guid Id { get; set; }

	public string FirstName { get; set; }
	public string LastName { get; set; }

	public bool IsBusy { get; set; }
}
