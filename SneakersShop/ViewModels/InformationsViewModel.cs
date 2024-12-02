using SneakersShop.Common;
using SneakersShop.Models;
using SneakersShop.Validators;

namespace SneakersShop.ViewModels
{
    public class InformationsViewModel : BaseViewModel
    {
        public InformationsViewModel()
        {

            FirstName.OnValueChange = Validate;
            LastName.OnValueChange = Validate;
            Phone.OnValueChange = Validate;
            Address.OnValueChange = Validate;
            City.OnValueChange = Validate;

            FirstName.Error = "";
            LastName.Error = "";
            Phone.Error = "";
            Address.Error = "";
            City.Error = "";

            LoadUserData();
        }

        public Prop<string> FirstName { get; set; } = new();
        public Prop<string> LastName { get; set; } = new();
        public Prop<string> Phone { get; set; } = new();
        public Prop<string> Address { get; set; } = new();
        public Prop<string?> City { get; set; } = new();

        public bool IsSaveChangesButtonEnabled { get; set; }

        private async void LoadUserData()
        {
            var storage = SecureStorage.Default;
            try
            {
                UserStorageModel userData = await storage.GetUser();

                if (userData.User != null)
                {
                    FirstName.Value = userData.User.FirstName;
                    LastName.Value = userData.User.LastName;
                    Phone.Value = userData.User.Phone;
                    Address.Value = userData.User.Address;
                    City.Value = userData.User.City;
                }

                Validate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Validate()
        {
            var validator = new InformationsViewModelValidator();

            var result = validator.Validate(this);

            if (!result.IsValid)
            {
                IsSaveChangesButtonEnabled = false;

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
                    City.Error = cityIdError.ErrorMessage;
                }
                else
                {
                    City.Error = "";
                }

            }
            else
            {
                IsSaveChangesButtonEnabled = true;
                FirstName.Error = "";
                LastName.Error = "";
                Phone.Error = "";
                Address.Error = "";
                City.Error = "";
            }

            OnPropertyChanged(nameof(IsSaveChangesButtonEnabled));
        }
    }
}
