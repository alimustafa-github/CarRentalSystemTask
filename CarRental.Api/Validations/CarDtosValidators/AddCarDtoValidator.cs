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


		RuleFor(x => x.DriverId)
			.NotEmpty().WithMessage("The DriverId cannot be empty.")
		    .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Invalid DriverId format,Make sure it is Guid");

	}
}









//// Infrastructure project
//using FluentValidation;

//public class MyDtoValidator : AbstractValidator<MyDto>
//{
//	public MyDtoValidator()
//	{
//		RuleFor(dto => dto.SerialNumber)
//			.NotEmpty().WithMessage("SerialNumber is required")
//			.Must(ValidateSerialNumber).WithMessage("SerialNumber must start with '255' followed by two digits");



//		// Other rules for other properties...

//		// Add more rules as needed
//	}

//	private bool ValidateSerialNumber(string serialNumber)
//	{
//		// Check if the serial number starts with "255" followed by two digits
//		return !string.IsNullOrEmpty(serialNumber) &&
//			   serialNumber.Length == 5 &&
//			   serialNumber.StartsWith("255") &&
//			   serialNumber.Substring(3).All(char.IsDigit);
//	}
//}
