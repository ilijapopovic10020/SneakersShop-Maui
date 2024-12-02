using SneakersShop.Common;
using SneakersShop.Models;
using SneakersShop.Services;
using SneakersShop.ViewModels;

namespace SneakersShop.Views;

public partial class InformationsPage : ContentPage
{
	public InformationsPage()
	{
		InitializeComponent();
        LoadCities();
	}

    private int selectedCityId;
    private async void LoadCities()
    {
        var getCitiesService = new CityService();

        List<GetCitiesModel> cities = await getCitiesService.GetCitiesAsync();

        if (cities != null && cities.Count != 0)
        {
            CityPicker.ItemsSource = cities;
            CityPicker.ItemDisplayBinding = new Binding("Name");
            var selectedCity = cities.FirstOrDefault(city => city.Name == ((InformationsViewModel)BindingContext).City.Value);

            if (selectedCity != null)
            {
                CityPicker.SelectedItem = selectedCity;
                selectedCityId = selectedCity.Id;
            }
        }
        else
        {
            await DisplayAlert("Error", "Failed to load cities", "OK");
        }
    }

    private void Edit_Button_Clicked(object sender, EventArgs e)
    {

    }

    private async void Cancel_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}