using CarRental.Core.Entities;

namespace CarRental.Api.Dtos.MembershipDtos;

public record AddMembershipDto
{
	public string Level { get; set; }
}
