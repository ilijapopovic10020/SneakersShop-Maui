using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using SneakersShop.Models;
using SneakersShop.Services;

namespace SneakersShop.Views;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
        LoadCities();
    }

    private async void SignUp_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var signUpService = new UserService();

            var signUpUser = new UserSignUpModel
            {
                FirstName = FirstNameField.Text,
                LastName = LastNameField.Text,
                Email = EmailField.Text,
                Password = PasswordField.Text,
                Username = UsernameField.Text,
                Address = AddressField.Text,
                Phone = PhoneField.Text,
                CityId = selectedCityId,
                BrithDate = BirthDatePicker.Date.Value,
            };

            //DisplayAlert("City Selected", $"Value = {BirthDatePicker.Date.Value}, Samo Date {BirthDatePicker.Date}", "OK");

            bool isSignedUp = await signUpService.SignUpAsync(signUpUser);

            CancellationTokenSource cancellationTokenSource = new();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Color.FromArgb("#BC262E"),
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(10),
            };

            string text = "Successfuly registered.";
            string actionButtonText = "Okay";

            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make( text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);

            await Navigation.PopAsync();

        } catch(Exception ex)
        {
            CancellationTokenSource cancellationTokenSource = new();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Color.FromArgb("#BC262E"),
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(10),
            };

            string text = ex.Message;
            string actionButtonText = "Okay";
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
        }
    }

    private async void LoadCities()
    {
        var getCitiesService = new CityService();

        List<GetCitiesModel> cities = await getCitiesService.GetCitiesAsync();

        if (cities != null && cities.Count != 0)
        {
            CityPicker.ItemsSource = cities;
            CityPicker.ItemDisplayBinding = new Binding("Name");
        }
        else
        {
            await DisplayAlert("Error", "Failed to load cities", "OK");
        }
    }

    private int selectedCityId;
    private void CityPicker_SelectedValueChanged(object sender, object e)
    {
        var selectedCity = (GetCitiesModel)CityPicker.SelectedItem;

        if (selectedCity != null)
        {
            selectedCityId = selectedCity.Id;
            DisplayAlert("City Selected", $"You selected {selectedCity.Name} with ID {selectedCityId}", "OK");
        }
    }

    private async void SignIn_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}