namespace CarRental.Api.Controllers;
[Route("api/authentication")]
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



	[HttpPost("assignrole/{email}/{role}")]
	public async Task<ApiResponse<bool>> AssignRole(string email, string role)
	{
		bool result = await _authService.AssignRoleAsync(email, role);
		if (result)
		{
			return new ApiResponse<bool>
			{
				IsSuccess = true,
				Message = "Role Assigned Successfully"
			};
		}
		else
		{
			return new ApiResponse<bool>
			{
				IsSuccess = false,
				Message = "Could not assign role , Please check that the email or the role name is correct"
			};
		}

	}
	//[Authorize(Roles = nameof(AppRoles.Admin))]
	//[HttpPost("removerole/{email}/{role}")]
	//public async Task<ApiResponse<bool>> RemoveRole(string email, string role)
	//{
	//	bool result = await _authService.RemoveRoleAsync(email, role);
	//	if (result)
	//	{
	//		return new ApiResponse<bool>
	//		{
	//			IsSuccess = true,
	//			Message = "Role Removed Successfully"
	//		};
	//	}
	//	else
	//	{
	//		return new ApiResponse<bool>
	//		{
	//			IsSuccess = false,
	//			Message = "Could not remove role , Please check that the email or the role name is correct"
	//		};
	//	}

	//}



	//[HttpPost("addrole")]
	//public async Task<ApiResponse<RoleDto>> AddRole([FromBody] RoleDto roleDto)
	//{
	//	RoleDto result = await _authService.AddRoleAsync(roleDto);
	//	if (result is not null)
	//	{
	//		return new ApiResponse<RoleDto>
	//		{
	//			IsSuccess = true,
	//			Data = roleDto,
	//			Message = "Role Created Successfully"
	//		};
	//	}
	//	else
	//	{
	//		return new ApiResponse<RoleDto>
	//		{
	//			IsSuccess = false,
	//			Data = null,
	//			Message = "Could not Create role "
	//		};
	//	}

	//}



}
