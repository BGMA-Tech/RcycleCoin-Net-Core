using Business.Services.TransactionServices.Dtos;
using Core.Entities;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.JsonResults.Concrete;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Business.Services.TransactionServices
{
    public class TransactionManager : ITransactionService
    {
        public async Task<IDataResult<ResultDataJson<TransactionDto>>> Add(CreatedTransactionDto createdTransactionDto)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage res = await client.PostAsJsonAsync(new BaseUrl().HostUrl + "transaction/", createdTransactionDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            IDataResult<ResultDataJson<TransactionDto>> result = new ConvertJsonDataResult<TransactionDto>().JsonToData(data);
                            if (result.Success)
                            {
                                return new SuccessDataResult<ResultDataJson<TransactionDto>>(result.Data);
                            }
                            return new ErrorDataResult<ResultDataJson<TransactionDto>>(result.Data);
                        }
                    }
                }
            }
            return new ErrorDataResult<ResultDataJson<TransactionDto>>(string.Empty);
        }

        public async Task<IDataResult<ResultDataJson<List<TransactionDto>>>> GetAll()
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "transaction/getall"))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            var result = new ConvertJsonDataResult<List<TransactionDto>>().JsonToData(data);
                            if (result.Success)
                            {
                                return new SuccessDataResult<ResultDataJson<List<TransactionDto>>>(result.Data);
                            }
                            return new ErrorDataResult<ResultDataJson<List<TransactionDto>>>(result.Data);
                        }
                    }
                }
            }
            return new ErrorDataResult<ResultDataJson<List<TransactionDto>>>(string.Empty);
        }

        public async Task<IDataResult<ResultDataJson<List<TransactionDto>>>> GetAllById(string id)
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "transaction/getallbyid?id=" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            IDataResult<ResultDataJson<List<TransactionDto>>> result = new ConvertJsonDataResult<List<TransactionDto>>().JsonToData(data);
                            if (result.Success)
                            {
                                return new SuccessDataResult<ResultDataJson<List<TransactionDto>>>(result.Data);
                            }
                            return new ErrorDataResult<ResultDataJson<List<TransactionDto>>>(result.Data);
                        }
                    }
                }
            }
            return new ErrorDataResult<ResultDataJson<List<TransactionDto>>>(string.Empty);
        }

        public async Task<IDataResult<ResultDataJson<TransactionDto>>> GetById(string id)
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "transaction/getbyid?id=" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            IDataResult<ResultDataJson<TransactionDto>> result = new ConvertJsonDataResult<TransactionDto>().JsonToData(data);
                            if (result.Success)
                            {
                                return new SuccessDataResult<ResultDataJson<TransactionDto>>(result.Data);
                            }
                            return new ErrorDataResult<ResultDataJson<TransactionDto>>(result.Data);
                        }
                    }
                }
            }
            return new ErrorDataResult<ResultDataJson<TransactionDto>>(string.Empty);
        }
    }
}
