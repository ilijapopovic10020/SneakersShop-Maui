using Java.Lang;
using SneakersShop.Models;
using SneakersShop.Services;
using SneakersShop.ViewModels;

namespace SneakersShop.Views;

public partial class CartPage : ContentPage
{
	public CartPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((CartViewModel)BindingContext).RefreshCart();
    }

}