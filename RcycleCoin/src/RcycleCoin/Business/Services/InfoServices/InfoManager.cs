using Business.Services.InfoServices.Dtos;
using Core.Entities;
using Core.Helper;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Business.Services.InfoServices
{
    public class InfoManager : IInfoService
    {
        public async Task<IJsonDataResult<ResultDataJson<InfoDto>>> Add(CreatedInfoDto createdInfoDto)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (HttpResponseMessage res = await client.PostAsJsonAsync(new BaseUrl().HostUrl + "info/", createdInfoDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError)
                        {
                            ResultDataJson<InfoDto>? result = JsonConvert.DeserializeObject<ResultDataJson<InfoDto>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<InfoDto>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<InfoDto> resultDataJson = new ResultDataJson<InfoDto>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<InfoDto>>(resultDataJson);
                        }
                    }
                }
            }
        }

        public async Task<IJsonDataResult<ResultDataJson<InfoDto>>> GetById(string id)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "info/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError && res.StatusCode != HttpStatusCode.NotFound)
                        {
                            ResultDataJson<InfoDto>? result = JsonConvert.DeserializeObject<ResultDataJson<InfoDto>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<InfoDto>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<InfoDto> resultDataJson = new ResultDataJson<InfoDto>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<InfoDto>>(resultDataJson);
                        }
                    }
                }
            }
        }

        public async Task<IJsonDataResult<ResultDataJson<InfoDto>>> Update(string id, UpdateInfoDto updateInfoDto)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsJsonAsync(new BaseUrl().HostUrl + "info/"+ id,updateInfoDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError && res.StatusCode != HttpStatusCode.NotFound)
                        {
                            ResultDataJson<InfoDto>? result = JsonConvert.DeserializeObject<ResultDataJson<InfoDto>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<InfoDto>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<InfoDto> resultDataJson = new ResultDataJson<InfoDto>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<InfoDto>>(resultDataJson);
                        }
                    }
                }
            }
        }
    }
}
