namespace CarRental.Api.Validations.DriverDtosValidators;

public class AddDriverDtoValidator : AbstractValidator<AddDriverDto>
{
	public AddDriverDtoValidator()
	{


		RuleFor(x => x.JoinDate)
		   .Must(BeWithinOneMonth)
		   .WithMessage("Date must be within one month from the current date.");

		RuleFor(d => d.LicenceNumber).NotEmpty().Length(8).WithMessage("The LicenceNumber should exactly be 8 charachters longs")
			.Must(licenceNumber => !licenceNumber.ToString().Contains(" ")).WithMessage("The LicenceNumber must not contain any spaces");

	}


	private bool BeWithinOneMonth(DateTime date)
	{
		DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
		DateTime oneMonthLater = DateTime.Now.AddMonths(1);

		return date > oneMonthAgo && date < oneMonthLater;
	}
}
