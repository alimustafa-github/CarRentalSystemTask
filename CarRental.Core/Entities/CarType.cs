namespace CarRental.Core.Entities;
public class CarType : IEntityBase
{
	public Guid Id { get; set; }
    public string Title { get; set; }

    public ICollection<Car> Cars { get; set; }


}
