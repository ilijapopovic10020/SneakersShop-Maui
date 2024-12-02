using SneakersShop.Common;
using SneakersShop.Models;
using SneakersShop.Services;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace SneakersShop.ViewModels
{
    public class AllProductsViewModel : BaseViewModel
    {
        public ObservableCollection<GetProductsModel> Products { get; set; }
        public Prop<string> Keyword { get; set; }
        public Prop<bool> IsLoading { get; set; }
        public ICommand SearchCommand { get; set; }


        public AllProductsViewModel()
        {
            Products = new ObservableCollection<GetProductsModel>();

            IsLoading = new Prop<bool>();
            Keyword = new Prop<string>();
            

            SearchCommand = new Command(GetProducts);
            GetProducts();
        }

        public async void GetProducts()
        {

            try
            {
                IsLoading.Value = true;

                var productService = new ProductService();
                IEnumerable<GetProductsModel> products = await productService.GetProductsAsync(Keyword.Value);

                Products = new ObservableCollection<GetProductsModel>(products);


                OnPropertyChanged(nameof(Products));
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
