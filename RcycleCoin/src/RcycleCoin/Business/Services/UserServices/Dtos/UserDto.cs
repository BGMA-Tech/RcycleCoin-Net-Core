using Business.Services.CoinServices.Dtos;
using Business.Services.InfoServices.Dtos;
using MongoDB.Bson;

namespace Business.Services.UserServices.Dtos
{
    public class UserDto
    {
        public string _id { get; set; }
        public string PersonelId { get; set; }
        public string Email { get; set; }
        public CoinDto Coin { get; set; }
        public InfoDto Info { get; set; }
    }
}
