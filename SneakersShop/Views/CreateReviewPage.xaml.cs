using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using SneakersShop.Common;
using SneakersShop.Models;
using SneakersShop.Services;
using SneakersShop.ViewModels;

namespace SneakersShop.Views;

public partial class CreateReviewPage : ContentPage
{
    private int _productId;
	public CreateReviewPage(int productId)
	{
        _productId = productId;
		InitializeComponent();
	}

    private async void Go_Back_ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void Create_Review_TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var _postReview = new ReviewService();
        var _selectedRating = ((CreateReviewViewModel)BindingContext).SelectedRating;

        try
        {
            var _reviewService = new ReviewService();

            var _reviewModel = new ReviewModel
            {
                Text = Text.Text,
                ProductId = _productId,
                Stars = _selectedRating
            };


            bool isCreatedReview = await _reviewService.PostReview(_reviewModel);

            CancellationTokenSource cancellationTokenSource = new();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Color.FromArgb("#BC262E"),
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(10),
            };

            string text = "Mnogo si moderna maćko majke mi.";
            string actionButtonText = "Okay";

            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);

            await Navigation.PopAsync();

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

    private void EditorField_TextChanged(object sender, TextChangedEventArgs e)
    {
        var viewModel = (CreateReviewViewModel)BindingContext;

        // Ažuriraj vrednost broja karaktera u ViewModel-u
        viewModel.CharacterCount.Value = $"{e.NewTextValue.Length}/150";
    }
}