using CarRental.Api.Dtos;
using CarRental.Api.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly IAuthService _authService;

	public AuthController(IAuthService authService)
    {
		_authService = authService;
	}

	[HttpPost("register")]
	public async Task<ApiResponse<string>> Register([FromBody] RegistrationRequestDto registrationRequestDto)
	{
		var errorMessage = await _authService.RegisterAsync(registrationRequestDto);
		if (!string.IsNullOrEmpty(errorMessage))
		{
			return new ApiResponse<string>
			{
				IsSuccess = false,
				Data = "",
				Message = errorMessage
			};
		}
		return new ApiResponse<string>
		{
			IsSuccess = true,
			Data = "",
			Message = "You have successfully registered"
		};
	}



	[HttpPost("login")]
	public async Task<ApiResponse<string>> Login([FromBody] LoginRequestDto model)
	{
		var loginResponse = await _authService.LoginAsync(model);
		if (string.IsNullOrEmpty(loginResponse))
		{
			return new ApiResponse<string>
			{
				IsSuccess = false,
				Data = "",
				Message = "incorrect email or password"
			};
		}
		return new ApiResponse<string>
		{
			IsSuccess = true,
			Data = loginResponse,
			Message = "You have successfully authenticated"
		};
	}
}
