using SneakersShop.Common;
using SneakersShop.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public SignInViewModel()
        {
            Email.OnValueChange = Validate;
            Password.OnValueChange = Validate;

            Email.Value = "ilija@gmail.com";
            Password.Value = "sifra123";


        }

        public Prop<string> Email { get; set; } = new();
        public Prop<string> Password { get; set; } = new();

        public bool IsSignInButtonEnabled { get; set; }

        private void Validate()
        {
            var validator = new SignInViewModelValidator();

            var result = validator.Validate(this);

            if (!result.IsValid)
            {
                IsSignInButtonEnabled = false;
                var passwordError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Password"));

                if (passwordError != null)
                {
                    Password.Error = passwordError.ErrorMessage;
                }
                else
                {
                    Password.Error = "";
                }

                var emailError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Email"));

                if (emailError != null)
                {
                    Email.Error = emailError.ErrorMessage;
                }
                else
                {
                    Email.Error = "";
                }
            }
            else
            {
                IsSignInButtonEnabled = true;
                Email.Error = "";
                Password.Error = "";
            }

            OnPropertyChanged(nameof(IsSignInButtonEnabled));
        }
    }
}
