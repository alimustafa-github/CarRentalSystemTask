﻿using CarRental.Api.Dtos;
using FluentValidation;

namespace CarRental.Api.Validations;

public class DriverDtoValidator : AbstractValidator<DriverDto>
{
    public DriverDtoValidator()
    {
        RuleFor(d => d.FirstName).NotEmpty().MinimumLength(3).MaximumLength(15).WithMessage("The First Name should be a minimum of 3 character long and cannot exceed 15 characters");
		RuleFor(d => d.LastName).NotEmpty().MinimumLength(3).MaximumLength(15).WithMessage("The Last Name should be a minimum of 3 character long and cannot exceed 15 characters");

	}
}