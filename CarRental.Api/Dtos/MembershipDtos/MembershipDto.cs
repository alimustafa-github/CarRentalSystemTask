using CarRental.Core.Entities;

namespace CarRental.Api.Dtos.MembershipDtos;

public record MembershipDto
{
	public Guid Id { get; set; }
	public string Level { get; set; }
}
