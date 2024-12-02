using FluentValidation;
using SneakersShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Validators
{
    public class SignUpViewModelValidator  : AbstractValidator<SignUpViewModel>
    {
        public SignUpViewModelValidator()
        {
            RuleFor(x => x.Email.Value).NotEmpty()
                                 .WithMessage("Email is required")
                                 .EmailAddress()
                                 .WithMessage("Invalid email format");

            RuleFor(x => x.FirstName.Value).NotEmpty()
                                     .WithMessage("First Name is required");

            RuleFor(x => x.LastName.Value).NotEmpty()
                                    .WithMessage("First Name is required");

            RuleFor(x => x.Username.Value).NotEmpty()
                                    .WithMessage("Username is required")
                                    .Matches("^(?=[a-zA-Z0-9._]{4,20}$)(?!.*[_.]{2})[^_.].*[^_.]$")
                                    .WithMessage("Username invalid format - 4 min, 20 max, letters, numbers nad special characters(.,_)");

            RuleFor(x => x.Address.Value).NotEmpty()
                                   .WithMessage("Address is required");

            RuleFor(x => x.Phone.Value).NotEmpty()
                                 .WithMessage("Phone is required")
                                 .Matches("^(06)[0-9]{7,8}$")
                                 .WithMessage("Phone invalid format");

            RuleFor(x => x.Password.Value).NotEmpty()
                                    .WithMessage("Password is required")
                                    .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{4,}$")
                                    .WithMessage("Password invalid format - 4 min letters and numbers only");


            When(x => x.BirthDate != null, () =>
            {
                RuleFor(x => x.BirthDate.Value).NotEmpty()
                                         .WithMessage("Birth Date is required")
                                         .Must(x => x < DateTime.UtcNow)
                                         .WithMessage("Birth Date invalid format");
            });

            RuleFor(x => x.CityId.Value).NotEmpty()
                                  .WithMessage("City is required");



            //RuleFor(x => x.Image.Value).Must(x => uploader.IsExtensionValid(x) &&
            //                                        new List<string> { "jpg", "png", "jpeg" }.Contains(uploader.GetExtension(x)))
            //                        .WithMessage("Invalid file extesion. Allowed are .jpg, .png and .jpeg");

        }
    }
}
