using Business.Services.UserServices.Dtos;
using Core.Entities;
using Core.Security.JWT;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.JsonResults.Concrete;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Business.Services.UserServices
{
    public class UserManager : IUserService
    {
        public async Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage res = await client.PostAsJsonAsync(new BaseUrl().HostUrl + "user/login", userForLoginDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            var result = new ConvertJsonDataResult<AccessToken>().JsonToData(data);
                            if (result.Success)
                            {
                                return new SuccessDataResult<AccessToken>(result.Data.Data);
                            }
                            return new ErrorDataResult<AccessToken>(result.Message);
                        }
                    }
                }
            }
            return new SuccessDataResult<AccessToken>(string.Empty);
        }

        public async Task<IDataResult<AccessToken>> Register(UserForRegisterDto userForRegisterDto)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage res = await client.PostAsJsonAsync(new BaseUrl().HostUrl + "user/register", userForRegisterDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();

                        if (data != null)
                        {
                            var result = new ConvertJsonDataResult<AccessToken>().JsonToData(data);
                            if (result.Success)
                            {
                                return new SuccessDataResult<AccessToken>(result.Data.Data);
                            }
                            return new ErrorDataResult<AccessToken>();
                        }
                    }
                }
            }
            return new ErrorDataResult<AccessToken>(string.Empty);
        }

        public async Task<IDataResult<ResultDataJson<UserDto>>> GetById(string userId)
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "user/getVerifyId?userId=" + userId))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            IDataResult<ResultDataJson<UserDto>> result = new ConvertJsonDataResult<UserDto>().JsonToData(data);
                            if (result.Success)
                            {
                                return new SuccessDataResult<ResultDataJson<UserDto>>(result.Data);
                            }
                            return new ErrorDataResult<ResultDataJson<UserDto>>(result.Data);
                        }
                    }
                }
            }
            return new ErrorDataResult<ResultDataJson<UserDto>>(string.Empty);
        }
    }
}
