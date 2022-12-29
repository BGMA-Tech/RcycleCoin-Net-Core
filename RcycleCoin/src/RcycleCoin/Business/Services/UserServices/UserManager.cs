using Business.Services.AuthServices;
using Business.Services.InfoServices.Dtos;
using Business.Services.TransactionServices.Dtos;
using Business.Services.UserServices.Dtos;
using Core.Entities;
using Core.Helper;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Constants;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Business.Services.UserServices
{
    public class UserManager : IUserService
    {
        private readonly IAuthService _authService;

        public UserManager(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IJsonDataResult<ResultDataJson<AccessToken>>> Login(UserForLoginDto userForLoginDto)
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
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError)
                        {
                            ResultDataJson<AccessTokenDto>? result = JsonConvert.DeserializeObject<ResultDataJson<AccessTokenDto>>(data);
                            AccessToken accessToken = await _authService.CreateAccessToken(new User
                            {
                                Email = result.Data.User.Email,
                                UserId = result.Data.User._id,
                                FirstName = result.Data.User.Info.FirstName,
                                LastName = result.Data.User.Info.LastName,
                                PersonelId = result.Data.User.PersonelId,
                                Rol = result.Data.User.Info.Role
                            });
                            UserIdDto.UserId = result.Data.User._id;
                            BaseHttpClient.Token = result.Data.Token;
                            ResultDataJson<AccessToken> resultDataJson = new ResultDataJson<AccessToken>();
                            resultDataJson.Data = accessToken;
                            return new SuccessJsonDataResult<ResultDataJson<AccessToken>>(resultDataJson);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<UserDto> resultDataJson = new ResultDataJson<UserDto>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<AccessToken>>(resultError.Error);
                        }
                    }
                }
            }
        }

        public async Task<IJsonDataResult<ResultDataJson<UserDto>>> Register(UserForRegisterDto userForRegisterDto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage res = await client.PostAsJsonAsync(new BaseUrl().HostUrl + "user/register", userForRegisterDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.InternalServerError && res.StatusCode != HttpStatusCode.Conflict)
                        {
                            ResultDataJson<UserDto>? result = JsonConvert.DeserializeObject<ResultDataJson<UserDto>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<UserDto>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<UserDto> resultDataJson = new ResultDataJson<UserDto>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<UserDto>>(resultDataJson);
                        }
                    }
                }
            }
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
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError && res.StatusCode != HttpStatusCode.NotFound)
                        {
                            ResultDataJson<UserDto>? result = JsonConvert.DeserializeObject<ResultDataJson<UserDto>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<UserDto>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<UserDto> resultDataJson = new ResultDataJson<UserDto>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<UserDto>>(resultDataJson);
                        }
                    }
                }
            }
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
                        if (res.StatusCode != HttpStatusCode.InternalServerError)
                        {
                            GetVerifyIdJson? result = JsonConvert.DeserializeObject<GetVerifyIdJson>(data);
                            return new SuccessJsonDataResult<GetVerifyIdJson>(result);
                        }
                        else
                        {
                            GetVerifyIdJson? result = JsonConvert.DeserializeObject<GetVerifyIdJson>(data);
                            return new ErrorJsonDataResult<GetVerifyIdJson>(result);
                        }
                    }
                }
            }
        }

        public async Task<IJsonDataResult<ResultDataJson<List<UserDto>>>> GetAll()
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "user/"))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError)
                        {
                            ResultDataJson<List<UserDto>>? result = JsonConvert.DeserializeObject<ResultDataJson<List<UserDto>>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<List<UserDto>>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<List<UserDto>> resultDataJson = new ResultDataJson<List<UserDto>>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<List<UserDto>>>(resultDataJson);
                        }
                    }
                }
            }
        }
    }
}
