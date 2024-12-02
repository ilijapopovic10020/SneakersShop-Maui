namespace SneakersShop.Views;

public partial class ChangePasswordPage : ContentPage
{
	public ChangePasswordPage()
	{
		InitializeComponent();
	}
    private void Edit_Button_Clicked(object sender, EventArgs e)
    {

    }

    private async void Cancel_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}