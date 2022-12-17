using Business.Services.CoinServices.Dtos;
using Business.Services.InfoServices.Dtos;
using Core.Entities;
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
        public async Task<IJsonDataResult<ResultDataJson<CreatedInfoDto>>> Add(CreatedInfoDto createdInfoDto)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage res = await client.PostAsJsonAsync(new BaseUrl().HostUrl + "info/", createdInfoDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<CreatedInfoDto>? result = JsonConvert.DeserializeObject<ResultDataJson<CreatedInfoDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<CreatedInfoDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<CreatedInfoDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<CreatedInfoDto>>();
        }

        public async Task<IJsonDataResult<ResultDataJson<InfoDto>>> GetById(string id)
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "Info/getbyid?id=" + id))
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

        public async Task<IJsonDataResult<ResultDataJson<UpdateInfoDto>>> Update(UpdateInfoDto updateInfoDto)
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsJsonAsync(new BaseUrl().HostUrl + "Info/update", updateInfoDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<UpdateInfoDto>? result = JsonConvert.DeserializeObject<ResultDataJson<UpdateInfoDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<UpdateInfoDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<UpdateInfoDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<UpdateInfoDto>>();
        }
    }
}
