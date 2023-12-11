namespace CarRental.Api.Dtos.CarDtos;

public record CarRequestDto
{
	public int PageNumber { get; set; } = 1;
	public int PageSize { get; set; } = 10;
    public bool SortBySerialNumber { get; set; } = false;

	public int SearchBySerialNumber { get; set; } = 0;

	public bool FilteringBySerialNumber
	{
		get => SearchBySerialNumber == 0 ? false : true;
		private set => FilteringBySerialNumber = value;
	}

}
