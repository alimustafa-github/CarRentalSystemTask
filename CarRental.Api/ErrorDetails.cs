using System.Text.Json;

namespace CarRental.Api;

public record ErrorDetails
{
	public int StatusCode { get; set; }
	public string? Message { get; set; }
	public Exception? InnerException { get; set; }

	public string? StackTrace { get; set; }

	public override string ToString()
	{
		return JsonSerializer.Serialize(this);
	}
}
