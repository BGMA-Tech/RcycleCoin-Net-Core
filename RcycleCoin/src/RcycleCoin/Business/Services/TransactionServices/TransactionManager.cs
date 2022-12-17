using Business.Services.InfoServices.Dtos;
using Business.Services.TransactionServices.Dtos;
using Core.Entities;
using Core.Helper;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Business.Services.TransactionServices
{
    public class TransactionManager : ITransactionService
    {
        public async Task<IJsonDataResult<ResultDataJson<CreatedTransactionDto>>> Add(CreatedTransactionDto createdTransactionDto,string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                using (HttpResponseMessage res = await client.PostAsJsonAsync(new BaseUrl().HostUrl + "transaction/", createdTransactionDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<CreatedTransactionDto>? result = JsonConvert.DeserializeObject<ResultDataJson<CreatedTransactionDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<CreatedTransactionDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<CreatedTransactionDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<CreatedTransactionDto>>();
        }

        public async Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAll(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "transaction/getall"))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<List<TransactionDto>>? result = JsonConvert.DeserializeObject<ResultDataJson<List<TransactionDto>>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<List<TransactionDto>>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<List<TransactionDto>>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<List<TransactionDto>>>();
        }

        public async Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAllById(string id,string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "transaction/getallbyid?id=" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<List<TransactionDto>>? result = JsonConvert.DeserializeObject<ResultDataJson<List<TransactionDto>>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<List<TransactionDto>>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<List<TransactionDto>>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<List<TransactionDto>>>();
        }

        public async Task<IJsonDataResult<ResultDataJson<TransactionDto>>> GetById(string id,string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "transaction/getbyid?id=" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            ResultDataJson<TransactionDto>? result = JsonConvert.DeserializeObject<ResultDataJson<TransactionDto>>(data);
                            if (result?.Data != null)
                            {
                                return new SuccessJsonDataResult<ResultDataJson<TransactionDto>>(result);
                            }
                            else
                            {
                                ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                                return new ErrorJsonDataResult<ResultDataJson<TransactionDto>>(resultError.Error);
                            }
                        }
                    }
                }
            }
            return new ErrorJsonDataResult<ResultDataJson<TransactionDto>>();
        }
    }
}
