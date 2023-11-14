namespace CarRental.Api;


public record ApiResponse<TData>(bool IsSuccess, TData Data, string? Message = null);
public record ApiResponse(bool IsSuccess, string? Message);