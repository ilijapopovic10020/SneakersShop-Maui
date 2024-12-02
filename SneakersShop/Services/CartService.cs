using SneakersShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Services
{
    public class CartService
    {
        private static CartService _instance;
        private readonly ObservableCollection<CartModel> _cartItems;

        public CartService()
        {
            _cartItems = new ObservableCollection<CartModel>();
        }

        public static CartService Instance => _instance ??= new CartService();

        public ObservableCollection<CartModel> CartItems => _cartItems;

        public void AddItem(CartModel cartItem)
        {
            var existingItem = _cartItems.FirstOrDefault(x =>
                x.ProductId == cartItem.ProductId &&
                x.Size == cartItem.Size &&
                x.Color == cartItem.Color);

            if (existingItem != null)
            {
                existingItem.Quantity.Value++;
            }
            else
            {
                _cartItems.Add(cartItem);
            }
        }

        public void RemoveItem(CartModel cartItem)
        {
            _cartItems.Remove(cartItem);
        }

        public ObservableCollection<CartModel> GetItems()
        {
            return _cartItems;
        }

        public void ClearCart()
        {
            _cartItems?.Clear();
        }

    }
}
