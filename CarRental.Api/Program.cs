using AutoMapper;
using CarRental.Api;
using CarRental.Api.Extensions;
using CarRental.Api.Services;
using CarRental.Api.Services.IService;
using CarRental.Core.Entities;
using CarRental.Infrastructure.Data;
using CarRental.Infrastructure.Data.EntitiesRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//For using In-Memory Caching
builder.Services.AddMemoryCache();


//Registering the AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Register the fluent Validation as a serivce
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

//Register our Custom serivces here
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddScoped<IJwtTokenGenerator,JwtTokenGenerator>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddTransient<EfCoreCarRepository>();
builder.Services.AddTransient<EfCoreUserRepository>();


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

builder.AddAppAuthentication();
builder.Services.AddAuthorization();



//Configure the program to work with sql database
string connectionString = builder.Configuration.GetConnectionString("MyConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));




var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	//ApplyPendingMigrations(app.Services);
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




//Apply Pending Migrations to the DataBase if any
static void ApplyPendingMigrations(IServiceProvider service)
{
	using var scope = service.CreateScope();
	var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

	if (dbContext.Database.GetPendingMigrations().Any())
		dbContext.Database.Migrate();

}