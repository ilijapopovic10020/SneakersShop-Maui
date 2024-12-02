using SneakersShop.Common;
using SneakersShop.Models;
using SneakersShop.Services;
using System.Collections.ObjectModel;

namespace SneakersShop.ViewModels
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        public GetProductsModel Product { get; set; }
        public Prop<bool> IsLoading { get; set; }

        public ProductDetailsViewModel(int productId)
        {

            Product = new GetProductsModel();
            IsLoading = new Prop<bool>();

            LoadProductDetails(productId);
        }

        private async void LoadProductDetails(int productId)
        {
            try
            {
                IsLoading.Value = true;

                var productService = new ProductService();

                Product = await productService.GetProductAsync(productId);

                OnPropertyChanged(nameof(Product));
                OnPropertyChanged(nameof(IsLoading));
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                IsLoading.Value = false;
            }
        }
    }
}
