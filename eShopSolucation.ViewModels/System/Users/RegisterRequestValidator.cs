using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolucation.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is require.")
                .MaximumLength(200).WithMessage("First name can not over 200 characters");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is require.")
                .MaximumLength(200).WithMessage("Last name can not over 200 characters");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 years.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is require.")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is require.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is require.");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Password is require.")
                .MinimumLength(6).WithMessage("Password is at least 6 characters.");

            RuleFor(x => x).Custom((request, context) =>
            {
                if(request.PassWord != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });

        }
    }
}
