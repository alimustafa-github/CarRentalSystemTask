namespace CarRental.Api.Services.IService;

public interface IAuthService
{
	Task<string> LoginAsync(LoginRequestDto loginRequestDto);
	Task<string> RegisterAsync(RegistrationRequestDto registrationRequestDto);
	Task<bool> AssignRoleAsync(string email, string roleName);

	//todo : The IAuthService is not responsible for add or working with Role , remove them!
}
