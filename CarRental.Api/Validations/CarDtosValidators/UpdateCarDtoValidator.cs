using System.ComponentModel;

namespace CarRental.Api.Validations.CarDtosValidators;

public class UpdateCarDtoValidator : AbstractValidator<UpdateCarDto>
{


	public UpdateCarDtoValidator()
	{
		RuleFor(c => c.DailyFaire).NotEmpty()
			.GreaterThan(0)
			.LessThan(100000.00m).WithMessage("The DailyFaire cannot be empty and cannot exceed 10000.00");


		RuleFor(x => x.DriverId)
				.NotEmpty().WithMessage("The DriverId cannot be empty.")
				.Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Invalid DriverId format,Make sure it is Guid");

	}

}
