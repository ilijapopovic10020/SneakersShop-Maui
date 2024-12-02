using FluentValidation;
using SneakersShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Validators
{
    public class CreateReviewViewModelValidator : AbstractValidator<CreateReviewViewModel>
    {
        public CreateReviewViewModelValidator()
        {
            RuleFor(x => x.Text.Value).NotEmpty().WithMessage("Text field cannot be empty");
        }
    }
}
