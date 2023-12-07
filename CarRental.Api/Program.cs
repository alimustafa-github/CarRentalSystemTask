var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.RegisterAppServices();
builder.AddAppAuthentication();

var app = builder.Build();
app.ConfigureExceptionHandler();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	ApplyPendingMigrations(app.Services);
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
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