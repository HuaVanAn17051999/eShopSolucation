using FluentValidation;
using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace eShopSolucation.ViewModels.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
       public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is require.");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Password is require.")
                .MinimumLength(6).WithMessage("Password is at least 6 characters.");
        }
    }
}
