using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Models
{
    public class OrderItem
    {
        public int productId { get; set; }
        public int quantity { get; set; }
    }

    public class OrderModel
    {
        public int storeId { get; set; }
        public int userId { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime promisedDate { get; set; }
        public string payment { get; set; }
        public List<OrderItem> orderItems { get; set; }
    }
}
