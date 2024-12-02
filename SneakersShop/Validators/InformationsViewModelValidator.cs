using FluentValidation;
using SneakersShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Validators
{
    public class InformationsViewModelValidator : AbstractValidator<InformationsViewModel>
    {
        public InformationsViewModelValidator()
        {
            RuleFor(x => x.FirstName.Value).NotEmpty()
                                     .WithMessage("First Name is required");

            RuleFor(x => x.LastName.Value).NotEmpty()
                                    .WithMessage("First Name is required");

            RuleFor(x => x.Address.Value).NotEmpty()
                                   .WithMessage("Address is required");

            RuleFor(x => x.Phone.Value).NotEmpty()
                                 .WithMessage("Phone is required")
                                 .Matches("^(06)[0-9]{7,8}$")
                                 .WithMessage("Phone invalid format");

            RuleFor(x => x.City.Value).NotEmpty()
                                  .WithMessage("City is required");
        }
    }
}
