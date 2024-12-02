using SneakersShop.Common;
using SneakersShop.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public SignUpViewModel()
        {
            FirstName.OnValueChange = Validate;
            LastName.OnValueChange = Validate;
            Email.OnValueChange = Validate;
            Username.OnValueChange = Validate;
            Password.OnValueChange = Validate;
            BirthDate.OnValueChange = Validate;
            Phone.OnValueChange = Validate;
            Address.OnValueChange = Validate;
            CityId.OnValueChange = Validate;

            FirstName.Error = "";
            LastName.Error = "";
            Email.Error = "";
            Username.Error = "";
            Password.Error = "";
            BirthDate.Error = "";
            Phone.Error = "";
            Address.Error = "";
            CityId.Error = "";
        }

        public Prop<string> FirstName { get; set; } = new();
        public Prop<string> LastName { get; set; } = new();
        public Prop<string> Email { get; set; } = new();
        public Prop<string> Username { get; set; } = new();
        public Prop<string> Password { get; set; } = new();
        public Prop<DateTime> BirthDate { get; set; } = new();
        public Prop<string> Image { get; set; } = new();
        public Prop<string> Phone { get; set; } = new();
        public Prop<string> Address { get; set; } = new();
        public Prop<int> CityId { get; set; } = new();


        public bool IsSignUpButtonEnabled { get; set; }

        private void Validate()
        {
            var validator = new SignUpViewModelValidator();

            var result = validator.Validate(this);

            if (!result.IsValid)
            {
                IsSignUpButtonEnabled = false;

                var firstNameError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("FirstName"));
                if (firstNameError != null)
                {
                    FirstName.Error = firstNameError.ErrorMessage;
                }
                else
                {
                    FirstName.Error = "";
                }

                var lastNameError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("LastName"));
                if (lastNameError != null)
                {
                    LastName.Error = lastNameError.ErrorMessage;
                }
                else
                {
                    LastName.Error = "";
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

                var usernameError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Username"));
                if (usernameError != null)
                {
                    Username.Error = usernameError.ErrorMessage;
                }
                else
                {
                    Username.Error = "";
                }

                var passwordError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Password"));
                if (passwordError != null)
                {
                    Password.Error = passwordError.ErrorMessage;
                }
                else
                {
                    Password.Error = "";
                }

                var birthDateError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("BirthDate"));
                if (birthDateError != null)
                {
                    BirthDate.Error = birthDateError.ErrorMessage;
                }
                else
                {
                    BirthDate.Error = "";
                }

                var imageError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Image"));
                if (imageError != null)
                {
                    Image.Error = imageError.ErrorMessage;
                }
                else
                {
                    Image.Error = "";
                }

                var phoneError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Phone"));
                if (phoneError != null)
                {
                    Phone.Error = phoneError.ErrorMessage;
                }
                else
                {
                    Phone.Error = "";
                }

                var addressError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Address"));
                if (addressError != null)
                {
                    Address.Error = addressError.ErrorMessage;
                }
                else
                {
                    Address.Error = "";
                }

                var cityIdError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("CityId"));
                if (cityIdError != null)
                {
                    CityId.Error = cityIdError.ErrorMessage;
                }
                else
                {
                    CityId.Error = "";
                }

            }
            else
            {
                IsSignUpButtonEnabled = true;
                FirstName.Error = "";
                LastName.Error = "";
                Email.Error = "";
                Username.Error = "";
                Password.Error = "";
                Password.Error = "";
                BirthDate.Error = "";
                Phone.Error = "";
                Address.Error = "";
                CityId.Error = "";
            }

            OnPropertyChanged(nameof(IsSignUpButtonEnabled));
        }
    }
}
