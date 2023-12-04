namespace CarRental.Api.Services.IService;

public interface IJwtTokenGenerator
{
	string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
}
