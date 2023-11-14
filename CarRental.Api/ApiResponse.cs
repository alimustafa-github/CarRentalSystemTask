namespace CarRental.Api;


public record ApiResponse<TData>(bool IsSuccess, TData Data, string? Message = null)
{
	public static ApiResponse<TData> Success(TData data) => new(true, data, null);
	public static ApiResponse<TData> Fail(string? message) => new(false, default!, message);
}
public record ApiResponse(bool IsSuccess, string? Message);