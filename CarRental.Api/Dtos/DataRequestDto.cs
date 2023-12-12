namespace CarRental.Api.Dtos;

public record DataRequestDto
{
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
	public string? SortProperty { get; set; }

	public bool Ascending { get; set; }

	public string? SearchProperty { get; set; }
	public string? SearchValue { get; set; }
}
