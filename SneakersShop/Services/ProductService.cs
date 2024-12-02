using Newtonsoft.Json;
using RestSharp;
using SneakersShop.Common;
using SneakersShop.Models;
using System.Net;

namespace SneakersShop.Services
{
    public class ProductService : BaseService
    {
        public async Task<List<GetProductsModel>> GetProductsAsync(string? keyword = null, int page = 1, int pageSize = 10)
        {
            var endpoint = $"products?page={page}&pageSize={pageSize}";

            if (!string.IsNullOrEmpty(keyword))
            {
                endpoint += $"&keyword={keyword}";
            }

            var request = new RestRequest(endpoint, Method.GET);

            var response = await Client.ExecuteAsync<List<GetProductsModel>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                //throw new Exception("An error occurred. Products cannot be displayed at this moment.");
                return new List<GetProductsModel>();
            }
        }

        public async Task<GetProductsModel> GetProductAsync(int id)
        {
            var endpoint = $"products/{id}";

            var request = new RestRequest(endpoint, Method.GET);

            var response = await Client.ExecuteAsync<GetProductsModel>(request);

            if(response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            } else
            {
                return new GetProductsModel();
            }
        }
    }
}
