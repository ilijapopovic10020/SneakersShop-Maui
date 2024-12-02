using Newtonsoft.Json;
using RestSharp;
using SneakersShop.Common;
using SneakersShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Services
{
    public class ReviewService : BaseService
    {
        public async Task<bool> PostReview(ReviewModel reviewModel)
        {
			try
			{
                var request = new RestRequest("reviews");

                var user = await SecureStorage.Default.GetUser();

                var reviewObj = new
                {
                    ProductId = reviewModel.ProductId,
                    ParentReviewId = reviewModel.ParentReviewId,
                    Stars = reviewModel.Stars,
                    Text = reviewModel.Text
                };

                var postJson = JsonConvert.SerializeObject(reviewModel);
                request.AddHeader("Authorization", "Bearer " + user.Token);
                request.AddJsonBody(postJson);

                var response = await Client.ExecuteAsync(request, Method.POST);

                return response.StatusCode == HttpStatusCode.Created;
            }
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
                return false;
			}

        }
    }
}
