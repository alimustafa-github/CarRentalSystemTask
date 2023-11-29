using AutoMapper;
using CarRental.Api.Dtos;
using CarRental.Api.Services.IService;
using CarRental.Core;
using CarRental.Core.Entities;
using CarRental.Infrastructure.Data;
using CarRental.Infrastructure.Data.EntitiesRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CarRental.Api.Services;

public class AuthService : IAuthService
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly IJwtTokenGenerator _jwtTokenGenerator;
	private readonly EfCoreUserRepository _userRepository;
	private readonly IMapper _mapper;


	public AuthService(EfCoreUserRepository userRepository, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
	{
		_userManager = userManager;
		_roleManager = roleManager;
		_jwtTokenGenerator = jwtTokenGenerator;
		_userRepository = userRepository;
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

			if (result.Succeeded && await AssignRoleAsync(user.Email, AppRoles.User.ToString()))
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


	public async Task<bool> AssignRoleAsync(string email, string roleName)
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


}
