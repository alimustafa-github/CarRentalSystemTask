namespace CarRental.Api.Dtos.UserDtos;

public record LoginRequestDto
{
    public string Email { get; set; }

    public string Password { get; set; }
}
