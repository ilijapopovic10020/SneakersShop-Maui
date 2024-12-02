using Newtonsoft.Json;
using RestSharp;
using SneakersShop.Common;
using SneakersShop.Models;
using System.IdentityModel.Tokens.Jwt;

namespace SneakersShop.Services
{
    public class UserService : BaseService
    {
        private class TokenResponse
        {
            public string? Token { get; set; }
        }
        public async Task<UserSignInModel> SignInAsync(string email, string password)
        {
            var request = new RestRequest("/Auth");

            request.AddJsonBody(new { email, password });

            var response = await Client.ExecutePostAsync<TokenResponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Error: {response.ErrorMessage}, Content: {response.Content}");
                throw new Exception("Authentication failed. Please check your credentials.");
            }

            if (string.IsNullOrWhiteSpace(response.Data.Token))
            {
                throw new Exception("Invalid token received.");
            }

            var claims = new JwtSecurityTokenHandler().ReadJwtToken(response.Data.Token);

            var userIdClaim = claims.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            var userExp = (claims.Claims.FirstOrDefault(x => x.Type == "exp")?.Value) ?? throw new Exception("Somethig went worng. Please try again.");
            DateTime expirationDate = double.Parse(userExp).ToDateTime();

            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                throw new Exception("User ID could not be retrieved from the token.");
            }

            return new UserSignInModel
            {
                Id = Int32.Parse(userIdClaim),
                Token = response.Data.Token,
                LoginExparation = expirationDate
            };
        }

        public async Task<UserGetByIdModel> GetUserByIdAsync(int userId, string token)
        {
            var request = new RestRequest($"Users/{userId}");

            request.AddHeader("Authorization", $"Bearer {token}");

            var response = await Client.ExecuteGetAsync<UserGetByIdModel>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("User cannot be found.");
            }
            Console.WriteLine(response.Content);
            return response.Data;
        }

        public async Task<bool> SignUpAsync(UserSignUpModel signUpObject)
        {
            var request = new RestRequest("Users");

            var userObject = new
            {
                signUpObject.Username,
                signUpObject.Email,
                signUpObject.Password,
                signUpObject.FirstName,
                signUpObject.LastName,
                signUpObject.Address,
                signUpObject.Phone,
                signUpObject.CityId,
                signUpObject.BrithDate,
                signUpObject.Image
            };

            var json = JsonConvert.SerializeObject(userObject);
            request.AddJsonBody(json);
            var response = await Client.ExecutePostAsync(request);
            return response.StatusCode == System.Net.HttpStatusCode.Created;
        }

        //public async Task<bool> UpdateUserAsync(User)
    }
}
