using SneakersShop.Common;
using SneakersShop.Models;
using SneakersShop.Services;
using System.Collections.ObjectModel;

namespace SneakersShop.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<GetProductsModel> PopularProducts { get; set; }
        public ObservableCollection<GetProductsModel> LatestProducts { get; set; }
        public ObservableCollection<GetProductsModel> TopRated { get; set; }

        public Prop<bool> IsLoading { get; set; }

        public HomeViewModel()
        {
            PopularProducts = new ObservableCollection<GetProductsModel>();
            TopRated = new ObservableCollection<GetProductsModel>();
            LatestProducts = new ObservableCollection<GetProductsModel>();
            IsLoading = new Prop<bool>();


            LoadProducts();
        }

        private async void LoadProducts()
        {
            try
            {
                IsLoading.Value = true;

                var _productService = new ProductService();
                List<GetProductsModel> allProducts = await _productService.GetProductsAsync();

                PopularProducts = new ObservableCollection<GetProductsModel>(allProducts.Take(4).ToList());
                TopRated = new ObservableCollection<GetProductsModel>(allProducts.Where(x => x.AvgStar == "5").Take(4).ToList());
                LatestProducts = new ObservableCollection<GetProductsModel>(allProducts.Skip(Math.Max(0, allProducts.Count - 4)).ToList());

                OnPropertyChanged(nameof(PopularProducts));
                OnPropertyChanged(nameof(LatestProducts));
                OnPropertyChanged(nameof(TopRated));
                OnPropertyChanged(nameof(IsLoading));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
            finally
            {
                IsLoading.Value = false;
            }
        }
    }
}
