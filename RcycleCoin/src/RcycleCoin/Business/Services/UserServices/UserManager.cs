using Business.Services.TransactionServices.Dtos;
using Business.Services.UserServices.Dtos;
using Core.Entities;
using Core.Helper;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Business.Services.UserServices
{
    public class UserManager : IUserService
    {
        public async Task<IJsonDataResult<ResultDataJson<AccessTokenDto>>> Login(UserForLoginDto userForLoginDto)
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
                            ResultDataJson<AccessTokenDto>? result = JsonConvert.DeserializeObject<ResultDataJson<AccessTokenDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<AccessTokenDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<AccessTokenDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<AccessTokenDto>>();
        }

        public async Task<IJsonDataResult<ResultDataJson<AccessTokenDto>>> Register(UserForRegisterDto userForRegisterDto)
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
                            ResultDataJson<AccessTokenDto>? result = JsonConvert.DeserializeObject<ResultDataJson<AccessTokenDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<AccessTokenDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<AccessTokenDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<AccessTokenDto>>();
        }

        public async Task<IJsonDataResult<ResultDataJson<UserDto>>> GetById(string userId)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "user/" + userId))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<UserDto>? result = JsonConvert.DeserializeObject<ResultDataJson<UserDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<UserDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<UserDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<UserDto>>();
        }

        public async Task<IJsonDataResult<GetVerifyIdJson>> GetVerifyId(GetVerifyIdDto getVerifyIdDto)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage res = await client.PostAsJsonAsync(new BaseUrl().HostUrl + "user/getVerifyId", getVerifyIdDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            GetVerifyIdJson result = JsonConvert.DeserializeObject<GetVerifyIdJson>(data);
                            return new SuccessJsonDataResult<GetVerifyIdJson>(result);
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<GetVerifyIdJson>();
        }

    }
}
