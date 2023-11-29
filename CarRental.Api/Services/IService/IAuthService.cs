using CarRental.Api.Dtos;
using CarRental.Core.Entities;

namespace CarRental.Api.Services.IService;

public interface IAuthService
{
	Task<string> LoginAsync(LoginRequestDto loginRequestDto);
	Task<string> RegisterAsync(RegistrationRequestDto registrationRequestDto);
}
