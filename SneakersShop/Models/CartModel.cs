using SneakersShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Models
{
    public class CartModel
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
        public double Size { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public Prop<int> Quantity { get; set; }
    }
}
