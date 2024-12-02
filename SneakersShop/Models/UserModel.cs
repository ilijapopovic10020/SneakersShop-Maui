using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Models
{
    public class UserSignInModel : BaseModel
    {
        public string? Token { get; set; }
        public DateTime LoginExparation { get; set; }
    }

    public class UserGetByIdModel : BaseModel
    {
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Role { get; set; }
        public string? Image { get; set; }
    }

    public class UserStorageModel
    {
        public UserGetByIdModel? User { get; set; }
        public string? Token { get; set; }
        public DateTime LoginExparation { get; set; }
        public bool ShouldBeLoggedOut => LoginExparation < DateTime.UtcNow;
    }

    public class UserSignUpModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime BrithDate { get; set; }
        public int CityId { get; set; }
        public string? Image { get; set; }
    }
}
