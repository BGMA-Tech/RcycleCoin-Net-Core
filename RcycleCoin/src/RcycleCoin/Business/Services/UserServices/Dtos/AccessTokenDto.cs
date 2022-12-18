using Business.Services.CoinServices.Dtos;

namespace Business.Services.UserServices.Dtos
{
    public class AccessTokenDto
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
