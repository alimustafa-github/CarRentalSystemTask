namespace CarRental.Api.Services.IService;

public interface IUserService
{
	Task<string> LoginAsync(LoginRequestDto loginRequestDto);
	Task<string> RegisterAsync(RegistrationRequestDto registrationRequestDto);

	Task<ApplicationUserDto> UpdateUserAsync(string id, UpdateUserDto updateUserDto);

	Task<ApplicationUserDto> GetUserByEmailAsync(string email);
	Task<ApplicationUserDto> GetUserByIdAsync(string id);

	Task<IEnumerable<ApplicationUserDto>> GetAllUsersAsync();
	Task DeleteUserAsync(string id);
	//todo : The IAuthService is not responsible for add or working with Role , remove them!
}
