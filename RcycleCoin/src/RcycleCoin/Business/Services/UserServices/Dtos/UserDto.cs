using Business.Services.CoinServices.Dtos;
using Business.Services.InfoServices.Dtos;

namespace Business.Services.UserServices.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string PersonelId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public InfoDto Info { get; set; }
        public CoinDto Coin { get; set; }
    }
}
