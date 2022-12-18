using Business.Services.CoinServices.Dtos;
using Core.Entities;
using Core.Helper;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Net.Http.Json;

namespace Business.Services.CoinServices
{
    public class CoinManager : ICoinService
    {
        public async Task<IJsonDataResult<ResultDataJson<CoinDto>>> GetById(string id,string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "coin/" + id))
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

        public async Task<IJsonDataResult<ResultDataJson<CoinDto>>> Delete(string id,string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                using (HttpResponseMessage res = await client.DeleteAsync(new BaseUrl().HostUrl + "coin/" + id))
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

        public async Task<IJsonDataResult<ResultDataJson<UpdatedCoinDto>>> Update(UpdatedCoinDto updatedCoinDto,string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                using (HttpResponseMessage res = await client.PostAsJsonAsync(new BaseUrl().HostUrl + "Coin/", updatedCoinDto._id))
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
