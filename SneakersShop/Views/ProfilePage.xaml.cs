using SneakersShop.Common;

namespace SneakersShop.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
        LoadUserData();
	}

    private async void LoadUserData()
    {
        var user = await SecureStorage.Default.GetUser();
        FullName.Text = $"{user.User?.FirstName} {user.User?.LastName}";
        Email.Text = $"{user.User?.Email}";
        ImageSource.Source = user.User.Image;
    }
    private async void Orders_TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new OrdersPage());
    }

    private async void Informations_TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new InformationsPage());
    }

    private async void Change_password_TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ChangePasswordPage());
    }
}