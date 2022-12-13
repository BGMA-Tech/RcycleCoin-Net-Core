using Business.Services.UserServices.Dtos;
using Core.Security.JWT;
using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.UserServices
{
    public interface IUserService
    {
        public Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);
        public Task<IDataResult<AccessToken>> Register(UserForRegisterDto userForRegisterDto);
        public Task<IDataResult<ResultDataJson<UserDto>>> GetById(string userId);
    }
}
