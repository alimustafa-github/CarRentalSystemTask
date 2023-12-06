namespace CarRental.Api.Services.IService;

public interface IUserService
{
	Task<string> LoginAsync(LoginRequestDto loginRequestDto);
	Task<string> RegisterAsync(RegistrationRequestDto registrationRequestDto);
	Task<bool> AssignRoleAsync(string email, string roleName);

	Task<ApplicationUserDto> UpdateUserAsync(string id, UpdateUserDto updateUserDto);

	Task<ApplicationUserDto> GetUserByEmailAsync(string email);
	Task<ApplicationUserDto> GetUserByIdAsync(string id);

	Task<IEnumerable<ApplicationUserDto>> GetAllUsersAsync();
	Task<ApplicationUserDto> DeleteUserAsync(string id);
	//todo : The IAuthService is not responsible for add or working with Role , remove them!
}
