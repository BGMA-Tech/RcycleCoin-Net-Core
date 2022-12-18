using Core.Utilities.Security.Jwt;
using Entities.Concrete;

namespace Business.Services.AuthServices
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);
    }
}
