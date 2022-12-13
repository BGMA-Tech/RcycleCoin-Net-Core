using Business.Services.CoinServices.Dtos;
using Core.Entities;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.JsonResults.Concrete;
using System.Net.Http.Json;

namespace Business.Services.CoinServices
{
    public class CoinManager : ICoinService
    {
        public async Task<IDataResult<ResultDataJson<CoinDto>>> GetById(string id)
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
                            IDataResult<ResultDataJson<CoinDto>> result = new ConvertJsonDataResult<CoinDto>().JsonToData(data);
                            if (result.Success)
                            {
                                return new SuccessDataResult<ResultDataJson<CoinDto>>(result.Data);
                            }
                            return new ErrorDataResult<ResultDataJson<CoinDto>>(result.Data);
                        }
                    }
                }
            }
            return new ErrorDataResult<ResultDataJson<CoinDto>>(string.Empty);
        }

        public async Task<IDataResult<ResultDataJson<CoinDto>>> Delete(string id)
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
                            IDataResult<ResultDataJson<CoinDto>> result = new ConvertJsonDataResult<CoinDto>().JsonToData(data);

                            if (result.Success)
                            {
                                return new SuccessDataResult<ResultDataJson<CoinDto>>(result.Data);
                            }
                            return new ErrorDataResult<ResultDataJson<CoinDto>>(result.Data);
                        }
                    }
                }
            }
            return new ErrorDataResult<ResultDataJson<CoinDto>>(string.Empty);
        }

        public async Task<IDataResult<ResultDataJson<UpdatedCoinDto>>> Update(UpdatedCoinDto updatedCoinDto)
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
                            IDataResult<ResultDataJson<UpdatedCoinDto>> result = new ConvertJsonDataResult<UpdatedCoinDto>().JsonToData(data);

                            if (result.Success)
                            {
                                return new SuccessDataResult<ResultDataJson<UpdatedCoinDto>>(result.Data);
                            }
                            return new ErrorDataResult<ResultDataJson<UpdatedCoinDto>>(result.Data);
                        }
                    }
                }

            }
            return new ErrorDataResult<ResultDataJson<UpdatedCoinDto>>(string.Empty);
        }

    }
}
