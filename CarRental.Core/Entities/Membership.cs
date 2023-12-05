namespace CarRental.Core.Entities;
public class Membership : IEntityBase
{
	public Guid Id { get; set; }
	public string Level { get; set; }
    public ICollection<Customer> Customers { get; set; }
}
