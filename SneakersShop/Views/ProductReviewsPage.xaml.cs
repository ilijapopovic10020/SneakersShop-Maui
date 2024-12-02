using SneakersShop.ViewModels;

namespace SneakersShop.Views;

public partial class ProductReviewsPage : ContentPage
{
    private int _productId;
	public ProductReviewsPage(int productId)
	{
        _productId = productId;
		InitializeComponent();
		BindingContext = new ProductDetailsViewModel(_productId);
	}

    private async void Go_Back_ImageButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CreateReviewPage(_productId));
    }
}