namespace CarRental.Api.Validations.CarDtosValidators;

public class AddCarDtoValidator : AbstractValidator<AddCarDto>
{
    public AddCarDtoValidator()
    {

		RuleFor(c => c.SerialNumber).NotEmpty()
				      .GreaterThan(0).LessThan(10000)
					  .WithMessage("The Serial Number cannot be empty and cannot exceed the Number 10000")
					  .Must(serialNumber => !serialNumber.ToString().Contains(" ")) 
					  .WithMessage("SerialNumber should not contain spaces.");


		RuleFor(x => x.CarTypeId)
			.NotEmpty().WithMessage("The CarTypeId cannot be empty.")
		    .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Invalid CarTypeId format,Make sure it Guid");

		RuleFor(c => c.DailyFaire).NotEmpty()
			.GreaterThan(0)
			.LessThan(100000.00m).WithMessage("The DailyFaire cannot be empty and cannot exceed 10000.00");

		RuleFor(c => c.Color).NotEmpty()
			.IsInEnum().WithMessage("Make sure that you chose a valid color");

		RuleFor(c => c.EngineCapacity).NotEmpty()
			.GreaterThan(0)
			.LessThan(100.00m).WithMessage("The EngineCapacity can not be empty and can not exceed 100.00");

	}
}






