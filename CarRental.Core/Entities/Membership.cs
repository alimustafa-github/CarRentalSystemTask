namespace CarRental.Core.Entities;
public class Membership : IEntityBase
{
	public Guid Id { get; set; }
	public string Level { get; set; }
    public virtual ICollection<Customer> Customers { get; set; }
}
