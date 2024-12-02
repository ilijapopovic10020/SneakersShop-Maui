using SneakersShop.Views;

namespace SneakersShop.Components;

public partial class VerticalProductComponent : ContentView
{
    public static readonly BindableProperty ImageProperty =
        BindableProperty.Create(nameof(Image), typeof(string), typeof(VerticalProductComponent), "");

    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(VerticalProductComponent), "");

    public static readonly BindableProperty BrandProperty =
        BindableProperty.Create(nameof(Brand), typeof(string), typeof(VerticalProductComponent), "");

    public static readonly BindableProperty PriceProperty =
        BindableProperty.Create(nameof(Price), typeof(string), typeof(VerticalProductComponent), "");

    public static readonly BindableProperty AvgStarsProperty =
        BindableProperty.Create(nameof(AvgStars), typeof(string), typeof(VerticalProductComponent), "");

    public static readonly BindableProperty ReviewsCountProperty =
        BindableProperty.Create(nameof(ReviewsCount), typeof(string), typeof(VerticalProductComponent), "");

    public static readonly BindableProperty ProductIdProperty =
        BindableProperty.Create(nameof(ProductId), typeof(int), typeof(VerticalProductComponent), 0);

    public string Image
    {
        get => (string)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }
    public string Brand
    {
        get => (string)GetValue(BrandProperty);
        set => SetValue(BrandProperty, value);
    }

    public string Price
    {
        get => (string)GetValue(PriceProperty);
        set => SetValue(PriceProperty, value);
    }

    public string AvgStars
    {
        get => (string)GetValue(AvgStarsProperty);
        set => SetValue(AvgStarsProperty, value);
    }

    public string ReviewsCount
    {
        get => (string)GetValue(ReviewsCountProperty);
        set => SetValue(ReviewsCountProperty, value);
    }

    public int ProductId
    {
        get => (int)GetValue(ProductIdProperty);
        set => SetValue(ProductIdProperty, value);
    }

    public VerticalProductComponent()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ProductDetailsPage(ProductId));
    }
}