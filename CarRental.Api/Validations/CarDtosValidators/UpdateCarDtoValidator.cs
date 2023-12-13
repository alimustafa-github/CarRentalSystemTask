namespace CarRental.Api.Validations.CarDtosValidators;

public class UpdateCarDtoValidator : AbstractValidator<UpdateCarDto>
{
	public UpdateCarDtoValidator()
	{
		RuleFor(c => c.DailyFaire).NotEmpty()
			.GreaterThan(0)
			.LessThan(100000.00m).WithMessage("The DailyFaire cannot be empty and cannot exceed 10000.00");
	}

}
