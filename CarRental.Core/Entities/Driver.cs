﻿namespace CarRental.Core.Entities;
public class Driver : IEntityBase
{
	public Guid Id { get; set; }

	public string FirstName { get; set; }
	public string LastName { get; set; }

	public bool IsBusy { get; set; }
}
