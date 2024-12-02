using FluentValidation;
using SneakersShop.ViewModels;

namespace SneakersShop.Validators
{
    internal class ChangePasswordViewModelValidator : AbstractValidator<ChangePasswordViewModel>
    {
        public ChangePasswordViewModelValidator()
        {
            RuleFor(x => x.OldPassword.Value).NotEmpty()
                                    .WithMessage("Old password is required");

            RuleFor(x => x.Password.Value).NotEmpty()
                                    .WithMessage("Password is required")
                                    .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{4,}$")
                                    .WithMessage("Password invalid format - 4 min letters and numbers only");
            RuleFor(x => x.PasswordConfirm.Value).NotEmpty()
                                        .WithMessage("Confirm your password")
                                        .Matches(x => x.Password.Value)
                                        .WithMessage("Confirm your password");
        }
    }
}
