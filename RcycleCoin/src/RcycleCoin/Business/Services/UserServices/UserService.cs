using Business.Services.UserServices.Dtos;
using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.UserServices
{
    public interface IUserService
    {
        public Task<IJsonDataResult<ResultDataJson<AccessTokenDto>>> Login(UserForLoginDto userForLoginDto);
        public Task<IJsonDataResult<ResultDataJson<AccessTokenDto>>> Register(UserForRegisterDto userForRegisterDto);
        public Task<IJsonDataResult<ResultDataJson<UserDto>>> GetById(string userId);
    }
}
