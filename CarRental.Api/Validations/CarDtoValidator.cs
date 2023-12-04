using CarRental.Api.Dtos.CarDtos;
using FluentValidation;

namespace CarRental.Api.Validations;

public class CarDtoValidator : AbstractValidator<AddCarDto>
{
	public CarDtoValidator()
	{

		////Rules For The Type Property
		//RuleFor(c => c.Type).NotEmpty().WithMessage("The Type of the car should not be empty");
		//RuleFor(c => c.Type).MinimumLength(3).MaximumLength(30).WithMessage("The type of the car should at least greater than 3 characters long" +
		//	" and it should not exceeds 30 characters long");

		//RuleFor(c => c.DailyFaire)
		//	.NotEmpty().WithMessage("The DialyFaire is required")
		//	.When(c => c.Type == "Bmw")  // Apply the following rule only when Type is "Bmw"
		//	.GreaterThan(10000).WithMessage("DialyFaire for Bmw must be greater than 10000");



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
