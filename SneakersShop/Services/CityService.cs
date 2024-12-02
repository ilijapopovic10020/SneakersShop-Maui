using RestSharp;
using SneakersShop.Models;

namespace SneakersShop.Services
{
    public class CityService : BaseService
    {
        public async Task<List<GetCitiesModel>> GetCitiesAsync()
        {
            var request = new RestRequest("cities", Method.GET);
            var response = await Client.ExecuteAsync<List<GetCitiesModel>>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                // Obrada greške ili povratak prazne liste
                return new List<GetCitiesModel>();
            }
        }
    }
}
