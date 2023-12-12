using CarRental.Core.Interfaces;
using System.Xml;

namespace CarRental.Api.Extensions;

public static class ConfigureAppSerivces
{
	public static void RegisterAppServices(this WebApplicationBuilder builder)
	{
		//Register our Custom serivces here
		builder.Services.AddTransient<ICarService, CarService>();
		builder.Services.AddTransient<IDriverService, DriverService>();
		builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
		builder.Services.AddScoped<IUserService, UserService>();
		builder.Services.AddScoped<IRentedCarService, RentedCarService>();
		builder.Services.AddScoped<ICustomerService, CustomerService>();
		builder.Services.AddTransient<EfCoreCarRepository>();
		builder.Services.AddTransient<EfCoreDriverRepository>();
		builder.Services.AddTransient<EfCoreCustomerRepository>();
		builder.Services.AddTransient<EfCoreRentedCarRepository>();


		//Register the fluent Validation as a serivce
		builder.Services.AddFluentValidationAutoValidation();
		builder.Services.AddValidatorsFromAssemblyContaining<Program>();


		//Register the serivces for JWT
		builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
		builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
		builder.Services.AddSwaggerGen(option =>
		{
			option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
			{
				Name = "Authorization",
				Description = "Enter the Bearer Authorization string as following:	'Bearer Generated-JWT-Token'",
				In = ParameterLocation.Header,
				Type = SecuritySchemeType.ApiKey,
				Scheme = "Bearer"
			});
			option.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{

						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = JwtBearerDefaults.AuthenticationScheme
						}
					},new string[]{}
				}
			});
		});
		builder.Services.AddAuthorization();




		//Registering the AutoMapper
		IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
		builder.Services.AddSingleton(mapper);
		builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		builder.Services.AddMediatR(con => con.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

		//For using In-Memory Caching
		builder.Services.AddMemoryCache();




		//Configure the program to work with sql database
		string? connectionString = builder.Configuration.GetConnectionString("MyConnection");
		if (connectionString is not null)
		{
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(connectionString);
				options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
				options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Information)));
			});
		}
		else
		{
			throw new InvalidOperationException("Connection string is null or not found");
		}


	}
}
