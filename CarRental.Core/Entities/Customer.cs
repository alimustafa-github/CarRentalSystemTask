namespace CarRental.Core.Entities;
public class Customer : IEntityBase
{
	public Guid Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
}
