using Business.Services.CoinServices.Dtos;
using Business.Services.InfoServices.Dtos;
using Core.Entities;
using Core.Helper;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Business.Services.InfoServices
{
    public class InfoManager : IInfoService
    {
        public async Task<IJsonDataResult<ResultDataJson<InfoDto>>> Add(CreatedInfoDto createdInfoDto, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("Authorization", token);
                using (HttpResponseMessage res = await client.PostAsJsonAsync(new BaseUrl().HostUrl + "info/", createdInfoDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<InfoDto>? result = JsonConvert.DeserializeObject<ResultDataJson<InfoDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<InfoDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<InfoDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<InfoDto>>();
        }

        public async Task<IJsonDataResult<ResultDataJson<InfoDto>>> GetById(string id, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "info/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<InfoDto>? result = JsonConvert.DeserializeObject<ResultDataJson<InfoDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<InfoDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<InfoDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<InfoDto>>();
        }

        public async Task<IJsonDataResult<ResultDataJson<InfoDto>>> Update(string id, UpdateInfoDto updateInfoDto, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                using (HttpResponseMessage res = await client.PutAsJsonAsync(new BaseUrl().HostUrl + "info/", id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<InfoDto>? result = JsonConvert.DeserializeObject<ResultDataJson<InfoDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<InfoDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<InfoDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<InfoDto>>();
        }
    }
}
