using Business.Services.CoinServices.Dtos;
using Business.Services.TransactionServices.Dtos;
using Core.Entities;
using Core.Helper;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace Business.Services.CoinServices
{
    public class CoinManager : ICoinService
    {
        public async Task<IJsonDataResult<ResultDataJson<CoinDto>>> GetById(string id)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "coin/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError && res.StatusCode != HttpStatusCode.NotFound)
                        {
                            ResultDataJson<CoinDto>? result = JsonConvert.DeserializeObject<ResultDataJson<CoinDto>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<CoinDto>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<CoinDto> resultDataJson = new ResultDataJson<CoinDto>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<CoinDto>>(resultDataJson);
                        }
                    }
                }
            }
        }

        public async Task<IJsonDataResult<ResultDataJson<CoinDto>>> Delete(string id)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(new BaseUrl().HostUrl + "coin/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError)
                        {
                            ResultDataJson<CoinDto>? result = JsonConvert.DeserializeObject<ResultDataJson<CoinDto>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<CoinDto>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<CoinDto> resultDataJson = new ResultDataJson<CoinDto>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<CoinDto>>(resultDataJson);
                        }
                    }
                }
            }
        }

        public async Task<IJsonDataResult<ResultDataJson<CoinDto>>> Update(string id,UpdatedCoinDto updatedCoinDto)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsJsonAsync(new BaseUrl().HostUrl + "Coin/"+id, updatedCoinDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError && res.StatusCode != HttpStatusCode.NotFound)
                        {
                            ResultDataJson<CoinDto>? result = JsonConvert.DeserializeObject<ResultDataJson<CoinDto>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<CoinDto>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<CoinDto> resultDataJson = new ResultDataJson<CoinDto>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<CoinDto>>(resultDataJson);
                        }
                    }
                }
            }
        }
    }
}
