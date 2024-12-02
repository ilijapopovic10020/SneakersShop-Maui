using Newtonsoft.Json;
using SneakersShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Common
{
    public static class Extensions
    {
        public static DateTime ToDateTime(this double unixTimeStamp)
        {
            DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime()!;
            return dateTime;
        }

        public static async Task<UserStorageModel> GetUser(this ISecureStorage storage)
        {
            var userString = await storage.GetAsync("user");

            if (string.IsNullOrEmpty(userString))
            {
                throw new InvalidOperationException("Cannot deserialize an empty or null user string.");
            }

            var userStorageObject = JsonConvert.DeserializeObject<UserStorageModel>(userString) ?? throw new InvalidOperationException("Failed to deserialize the user object.");
            return userStorageObject;
        }

        public static async Task<List<GetProductsModel>> GetProducts(this ISecureStorage storage)
        {
            var productsString = await storage.GetAsync("products");

            if (string.IsNullOrEmpty(productsString))
            {
                throw new InvalidOperationException("Cannot deserialize an empty or null products string.");
            }

            var products = JsonConvert.DeserializeObject<List<GetProductsModel>>(productsString)
                           ?? throw new InvalidOperationException("Failed to deserialize the products object.");
            return products;
        }
    }
}
