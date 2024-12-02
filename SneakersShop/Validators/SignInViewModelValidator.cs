using FluentValidation;
using SneakersShop.ViewModels;

namespace SneakersShop.Validators
{
    public class SignInViewModelValidator : AbstractValidator<SignInViewModel>
    {
        public SignInViewModelValidator()
        {
            RuleFor(x => x.Email.Value).NotEmpty()
                                 .WithMessage("Email is required")
                                 .EmailAddress()
                                 .WithMessage("Invalid email format");

            RuleFor(x => x.Password.Value).NotEmpty()
                                    .WithMessage("Password is required")
                                    .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{4,}$")
                                    .WithMessage("Password invalid format - 4 min letters and numbers only");
        }
    }
}
