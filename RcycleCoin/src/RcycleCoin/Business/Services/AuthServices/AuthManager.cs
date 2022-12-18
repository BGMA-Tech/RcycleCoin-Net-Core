using Core.Utilities.Security.Jwt;
using Entities.Concrete;

namespace Business.Services.AuthServices
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            AccessToken accessToken = _tokenHelper.CreateToken(user);
            return accessToken;
        }
    }
}
