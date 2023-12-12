namespace CarRental.Api.Services;

public class UserService : IUserService
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly IJwtTokenGenerator _jwtTokenGenerator;
	private readonly IMapper _mapper;

	public UserService(IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
	{
		_userManager = userManager;
		_roleManager = roleManager;
		_jwtTokenGenerator = jwtTokenGenerator;
		_mapper = mapper;
	}


	public async Task<string> LoginAsync(LoginRequestDto loginRequestDto)
	{
		var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
		bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
		if (!isValid || user == null)
		{
			return string.Empty;
		}
		//if user is exist return the token
		var roles = await _userManager.GetRolesAsync(user);
		var token = _jwtTokenGenerator.GenerateToken(user, roles);

		return token;
	}

	public async Task<string> RegisterAsync(RegistrationRequestDto registrationRequestDto)
	{
		ApplicationUser user = _mapper.Map<ApplicationUser>(registrationRequestDto);

		try
		{
			var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

			if (result.Succeeded && await AssignRoleAsync(user.Email, AppRoles.Visitor.ToString()))
			{
				return string.Empty;
			}
			else
			{
				return result.Errors.FirstOrDefault().Description;
			}

		}
		catch (Exception ex)
		{
			return ex.Message.ToString();
		}
	}

	private async Task<bool> AssignRoleAsync(string email, string roleName)
	{
		var user = await _userManager.FindByEmailAsync(email);
		if (user != null)
		{
			if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
			{
				//create role if it does not exist
				_roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
			}
			await _userManager.AddToRoleAsync(user, roleName);
			return true;
		}
		return false;
	}

	public async Task<ApplicationUserDto> UpdateUserAsync(string id, UpdateUserDto updateUserDto)
	{
		ApplicationUser user = await _userManager.FindByIdAsync(id);
		var result = await _userManager.UpdateAsync(user);
		ApplicationUserDto userDto = _mapper.Map<ApplicationUserDto>(user);
		if (result.Succeeded)
		{
			return userDto;
		}
		else
		{
			return null;
		}
	}


	public async Task DeleteUserAsync(string id)
	{
		ApplicationUser user = await _userManager.FindByIdAsync(id);
		var result = await _userManager.DeleteAsync(user);
	}


	public async Task<IEnumerable<ApplicationUserDto>> GetAllUsersAsync()
	{
		IQueryable<ApplicationUser> users = _userManager.Users;
		if (users is null)
		{
			throw new ArgumentNullException();
		}
		else
		{
			IEnumerable<ApplicationUserDto> userDtos = _mapper.Map<IEnumerable<ApplicationUserDto>>(users);

			return userDtos;
		}

	}

	public async Task<ApplicationUserDto> GetUserByEmailAsync(string email)
	{
		ApplicationUser user = await _userManager.FindByEmailAsync(email);
		if (user is null)
		{
			throw new ArgumentNullException("Invalid Email");
		}
		ApplicationUserDto userDto = _mapper.Map<ApplicationUserDto>(user);
		return userDto;
	}

	public async Task<ApplicationUserDto> GetUserByIdAsync(string id)
	{
		ApplicationUser user = await _userManager.FindByIdAsync(id);
		ApplicationUserDto userDto = _mapper.Map<ApplicationUserDto>(user);
		return userDto;
	}


}