using Business.Services.CoinServices.Dtos;
using Core.Entities;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Business.Services.CoinServices
{
    public class CoinManager : ICoinService
    {
        public async Task<IJsonDataResult<ResultDataJson<CoinDto>>> GetById(string id)
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "Coin/getbyid?id=" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<CoinDto>? result = JsonConvert.DeserializeObject<ResultDataJson<CoinDto>>(data);
                            if(result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<CoinDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<CoinDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<CoinDto>>();
        }

        public async Task<IJsonDataResult<ResultDataJson<CoinDto>>> Delete(string id)
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(new BaseUrl().HostUrl + "Coin/delete?id=" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<CoinDto>? result = JsonConvert.DeserializeObject<ResultDataJson<CoinDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<CoinDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<CoinDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<CoinDto>>();
        }

        public async Task<IJsonDataResult<ResultDataJson<UpdatedCoinDto>>> Update(UpdatedCoinDto updatedCoinDto)
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsJsonAsync(new BaseUrl().HostUrl + "Coin/update", updatedCoinDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<UpdatedCoinDto>? result = JsonConvert.DeserializeObject<ResultDataJson<UpdatedCoinDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<UpdatedCoinDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<UpdatedCoinDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<UpdatedCoinDto>>();
        }
    }
}
