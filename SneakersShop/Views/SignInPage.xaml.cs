using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Newtonsoft.Json;
using SneakersShop.Models;
using SneakersShop.Services;

namespace SneakersShop.Views;

public partial class SignInPage : ContentPage
{
	public SignInPage()
	{
		InitializeComponent();
	}

    private async void SignIn_Button_Clicked(object sender, EventArgs e)
    {
        UserService signInService = new ();
        ProductService getProductsService = new ();

        try
        {
            UserSignInModel userSignIn = await signInService.SignInAsync(EmailField.Text, PasswordField.Text);
            

            if (userSignIn.Token != null)
            {
                UserGetByIdModel userDetails = await signInService.GetUserByIdAsync(userSignIn.Id, userSignIn.Token);

                if (userDetails != null)
                {
                    var userStorageObject = new
                    {
                        User = userDetails,
                        userSignIn.Token,
                        userSignIn.LoginExparation
                    };


                    await SecureStorage.Default.SetAsync("user", JsonConvert.SerializeObject(userStorageObject));

                    if (Application.Current != null)
                    {
                        Application.Current.MainPage = new MainPage();
                    }
                }
            }
        }
        catch (Exception ex)
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

    private async void SignUp_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }
}