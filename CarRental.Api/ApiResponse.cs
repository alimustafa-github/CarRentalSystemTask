namespace CarRental.Api;


public record ApiResponse<TData>
{
	public bool IsSuccess { get; set; }
	public int StatusCode { get; set; }
	public string? Message { get; set; } = string.Empty;
    public TData? Data { get; set; } 
}

