using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SneakersShop.Models;
using SneakersShop.Services;

namespace SneakersShop.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public ObservableCollection<CartModel> CartItems { get; set; }

        public double TotalPrice => CartItems.Sum(x => x.Price * x.Quantity.Value);

        public ICommand IncreaseQuantityCommand { get; }
        public ICommand DecreaseQuantityCommand { get; }
        public ICommand RemoveItemCommand { get; }
        public ICommand ClearCartCommand { get; }

        public CartViewModel()
        {
            CartItems = new ObservableCollection<CartModel>(CartService.Instance.GetItems());
            CartItems.CollectionChanged += CartItems_CollectionChanged;

            IncreaseQuantityCommand = new Command<CartModel>(IncreaseQuantity);
            DecreaseQuantityCommand = new Command<CartModel>(DecreaseQuantity);
            RemoveItemCommand = new Command<CartModel>(RemoveItem);
            ClearCartCommand = new Command(ClearCart);
        }

        private void CartItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TotalPrice));
        }

        private void IncreaseQuantity(CartModel cartItem)
        {
            cartItem.Quantity.Value++;
            OnPropertyChanged(nameof(TotalPrice));
        }

        private void DecreaseQuantity(CartModel cartItem)
        {
            if (cartItem.Quantity.Value > 1)
            {
                cartItem.Quantity.Value--;
            }
            else
            {
                RemoveItem(cartItem);
            }
            OnPropertyChanged(nameof(TotalPrice));
        }

        private void RemoveItem(CartModel cartItem)
        {
            CartService.Instance.RemoveItem(cartItem);
            CartItems.Remove(cartItem);
        }

        private void ClearCart()
        {
            CartService.Instance.ClearCart();
            CartItems.Clear();
        }

        public void RefreshCart()
        {
            CartItems.Clear(); // Očisti postojeću kolekciju
            foreach (var item in CartService.Instance.GetItems())
            {
                CartItems.Add(item); // Dodaj ažurirane stavke
            }

            // Obavesti UI o promeni, ako je potrebno
            OnPropertyChanged(nameof(TotalPrice));
        }
    }
}
