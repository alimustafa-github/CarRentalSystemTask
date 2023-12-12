namespace CarRental.Api.Controllers;
[Route("api/user")]
[ApiController]
public class UserConroller : ControllerBase
{
	private readonly IUserService _authService;

	public UserConroller(IUserService authService)
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
				StatusCode = StatusCodes.Status400BadRequest,
				Message = errorMessage
			};
		}
		return new ApiResponse<string>
		{
			IsSuccess = true,
			Data = "",
			StatusCode = StatusCodes.Status202Accepted,
			Message = "You have successfully registered"
		};
	}



	[HttpPost("login")]
	public async Task<ApiResponse<string>> Login([FromBody] LoginRequestDto loginRequestDto)
	{
		var loginResponse = await _authService.LoginAsync(loginRequestDto);
		if (string.IsNullOrEmpty(loginResponse))
		{
			return new ApiResponse<string>
			{
				IsSuccess = false,
				Data = "",
				StatusCode = StatusCodes.Status400BadRequest,
				Message = "incorrect email or password"
			};
		}
		return new ApiResponse<string>
		{
			IsSuccess = true,
			Data = loginResponse,
			StatusCode = StatusCodes.Status202Accepted,
			Message = "You have successfully authenticated"
		};
	}

	[HttpPut("updateuser/{id}")]
	public async Task<ApiResponse<ApplicationUserDto>> UpdateUser(string id, [FromBody] UpdateUserDto updateUserDto)
	{
		ApplicationUserDto userDto = await _authService.UpdateUserAsync(id, updateUserDto);
		if (userDto is not null)
		{
			return new ApiResponse<ApplicationUserDto>()
			{
				IsSuccess = true,
				Data = userDto,
				StatusCode = StatusCodes.Status200OK,
				Message = string.Empty
			};
		}
		else
		{
			//todo : get back and fix this issue
			return new ApiResponse<ApplicationUserDto>()
			{
				IsSuccess = false,
				Data = null,
				StatusCode = StatusCodes.Status400BadRequest,
				Message = "Failed to update"
			};
		}
	}



	[HttpDelete("deleteuser/{id}")]
	public async Task<ApiResponse<ApplicationUserDto>> DeleteUser(string id)
	{
		await _authService.DeleteUserAsync(id);
		return new ApiResponse<ApplicationUserDto>()
		{
			IsSuccess = true,
			Data = null,
			StatusCode = StatusCodes.Status204NoContent,
			Message = string.Empty
		};
	}



	[HttpGet("getuser/{id}")]
	public async Task<ApiResponse<ApplicationUserDto>> GetUserById(string id)
	{
		ApplicationUserDto userDto = await _authService.GetUserByIdAsync(id);
		if (userDto is not null)
		{
			return new ApiResponse<ApplicationUserDto>()
			{
				IsSuccess = true,
				Data = userDto,
				StatusCode = StatusCodes.Status200OK,
				Message = string.Empty
			};
		}
		else
		{
			//todo : get back and fix this issue
			return new ApiResponse<ApplicationUserDto>()
			{
				IsSuccess = false,
				Data = null,
				StatusCode = StatusCodes.Status404NotFound,
				Message = "There is no User mathches with the given identifier"
			};
		}
	}



	[HttpGet("getallusers")]
	public async Task<ApiResponse<IEnumerable<ApplicationUserDto>>> GetAllUSers()
	{
		IEnumerable<ApplicationUserDto> userDto = await _authService.GetAllUsersAsync();
		if (userDto is not null)
		{
			return new ApiResponse<IEnumerable<ApplicationUserDto>>()
			{
				IsSuccess = true,
				Data = userDto,
				StatusCode = StatusCodes.Status200OK,
				Message = string.Empty
			};
		}
		else
		{
			//todo : get back and fix this issue
			return new ApiResponse<IEnumerable<ApplicationUserDto>>()
			{
				IsSuccess = false,
				Data = null,
				StatusCode = StatusCodes.Status404NotFound,
				Message = string.Empty
			};
		}
	}


}
