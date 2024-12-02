using SneakersShop.Common;
using SneakersShop.Models;
using SneakersShop.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.ViewModels
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        public ChangePasswordViewModel()
        {

            OldPassword.OnValueChange = Validate;
            Password.OnValueChange = Validate;
            PasswordConfirm.OnValueChange = Validate;

            OldPassword.Error = "";
            Password.Error = "";
            PasswordConfirm.Error = "";

            Validate();
        }

        public Prop<string> OldPassword { get; set; } = new();
        public Prop<string> Password { get; set; } = new();
        public Prop<string> PasswordConfirm { get; set; } = new();


        private void Validate()
        {
            var validator = new ChangePasswordViewModelValidator();

            var result = validator.Validate(this);

            if (!result.IsValid)
            {
                var oldPassword = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("OldPassword"));
                if (oldPassword != null)
                {
                    OldPassword.Error = oldPassword.ErrorMessage;
                }
                else
                {
                    OldPassword.Error = "";
                }

                var password = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Password"));
                if (password != null)
                {
                    Password.Error = password.ErrorMessage;
                }
                else
                {
                    Password.Error = "";
                }


                var passwordConfirm = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("PasswordConfirm"));
                if (passwordConfirm != null)
                {
                    PasswordConfirm.Error = passwordConfirm.ErrorMessage;
                }
                else
                {
                    PasswordConfirm.Error = "";
                }



            }
            else
            {
                OldPassword.Error = "";
                Password.Error = "";
                PasswordConfirm.Error = "";
            }
        }
    }
}

