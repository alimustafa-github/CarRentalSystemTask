namespace CarRental.Api.Validations.CustomerDtosValidators;

public class AddCustomerDtoValidator : AbstractValidator<AddCustomerDto>
{
	public AddCustomerDtoValidator()
	{

		RuleFor(x => x.JoinDate)
		   .Must(BeWithinOneMonth)
		   .WithMessage("Join Date must be within one month from the current date.");


		RuleFor(c => c.LicenseNumber).Empty().When(c => !c.HasLicence).
			WithMessage("The Licnece number is empty as long the user does not have a lincence");

		RuleFor(d => d.LicenseNumber).NotEmpty()
			.WithMessage("The Licnece number should not be empty as long the user does have a lincence")
			.Length(8).WithMessage("The LicenceNumber should exactly be 8 charachters longs")
			.Must(licenceNumber => !licenceNumber.ToString().Contains(" ")).When(c => c.HasLicence).WithMessage("The LicenceNumber must not contain any spaces");

	}

	private bool BeWithinOneMonth(DateTime date)
	{
		DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
		DateTime oneMonthLater = DateTime.Now.AddMonths(1);

		return date > oneMonthAgo && date < oneMonthLater;
	}
}
