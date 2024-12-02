using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using SneakersShop.Common;
using SneakersShop.Models;
using SneakersShop.Services;
using SneakersShop.ViewModels;
using System.Threading;

namespace SneakersShop.Views;

public partial class ProductDetailsPage : ContentPage
{
    private int _productId;
    public ProductDetailsPage(int productId)
    {
        InitializeComponent();

        _productId = productId;
        BindingContext = new ProductDetailsViewModel(productId);
    }

    private async void Go_Back_ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ProductReviewsPage(_productId));
    }

    private async void Add_To_Cart_Button_Clicked(object sender, EventArgs e)
    {
        var product = ((ProductDetailsViewModel)BindingContext).Product;
        var user = await SecureStorage.Default.GetUser();
        var selectedSize = SizePicker.SelectedItem as Sizes;

        if (SizePicker.SelectedItem == null)
        {
            CancellationTokenSource cancellationTokenSource = new();
            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Color.FromArgb("#BC262E"),
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(10),
            };

            string text = "You mas select size before u add product to cart.";
            string actionButtonText = "Okay";
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);

        }
        else if (ColorPicker.SelectedItem == null)
        {
            CancellationTokenSource cancellationTokenSource = new();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Color.FromArgb("#BC262E"),
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(10),
            };

            string text = "You mas select color before u add product to cart.";
            string actionButtonText = "Okay";
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);

        } else
        {
            var items = CartService.Instance.GetItems();

            CartService.Instance.AddItem(new CartModel()
            {
                ProductId = _productId,
                Image = product.Image,
                Color = ColorPicker.SelectedItem.ToString(),
                UserId = user.User.Id,
                Name = product.Name,
                Price = product.Price,
                Size = selectedSize.Size,
                StoreId = 1,
                Quantity = new Prop<int> { Value = 1 }
            });

            CancellationTokenSource cancellationTokenSource = new();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Color.FromArgb("#BC262E"),
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(10),
            };

            string text = "Successfully added to cart.";
            string actionButtonText = "Okay";
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);

        }

    }
}