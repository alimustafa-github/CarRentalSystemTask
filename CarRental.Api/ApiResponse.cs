namespace CarRental.Api;


public record ApiResponse<TData>
{
    public bool IsSuccess { get; set; }
    public TData Data { get; set; } 
    public string? Message { get; set; } = string.Empty;
}

