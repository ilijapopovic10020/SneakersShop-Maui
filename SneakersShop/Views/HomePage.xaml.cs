using SneakersShop.Common;
using SneakersShop.Models;
using SneakersShop.Services;
using System.Collections.ObjectModel;

namespace SneakersShop.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void GoTo_ProductsPage_TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//AllProductsPage");
    }

    private async void GoTo_ProductsPageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AllProductsPage");
    }
}