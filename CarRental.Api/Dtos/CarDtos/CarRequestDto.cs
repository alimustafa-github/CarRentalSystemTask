namespace CarRental.Api.Dtos.CarDtos;

public record CarRequestDto
{
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
	public string? SortingProperty { get; set; }

	public bool Ascending { get; set; }

    public string? SearchProperty { get; set; }
    public string? SearchValue { get; set; }

    //public string SearchBySerialNumber { get; set; }
    //public Guid? TypeId { get; set; }

    //public bool FilteringBySerialNumber { get; set; } = false;

}
