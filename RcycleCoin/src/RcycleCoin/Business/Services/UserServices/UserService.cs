using Business.Services.UserServices.Dtos;
using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Core.Utilities.Security.Jwt;

namespace Business.Services.UserServices
{
    public interface IUserService
    {
        public Task<IJsonDataResult<ResultDataJson<AccessToken>>> Login(UserForLoginDto userForLoginDto);
        public Task<IJsonDataResult<ResultDataJson<UserDto>>> Register(UserForRegisterDto userForRegisterDto);
        public Task<IJsonDataResult<ResultDataJson<UserDto>>> GetById(string userId);
        public Task<IJsonDataResult<GetVerifyIdJson>> GetVerifyId(GetVerifyIdDto getVerifyIdDto);
    }
}
