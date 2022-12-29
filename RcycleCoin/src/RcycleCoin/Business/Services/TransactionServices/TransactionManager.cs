using Business.Services.TransactionServices.Dtos;
using Core.Entities;
using Core.Helper;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Business.Services.TransactionServices
{
    public class TransactionManager : ITransactionService
    {
        public async Task<IJsonDataResult<ResultDataJson<TransactionDto>>> Add(CreatedTransactionDto createdTransactionDto)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage res = await client.PostAsJsonAsync(new BaseUrl().HostUrl + "transaction/", createdTransactionDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError)
                        {
                            ResultDataJson<TransactionDto>? result = JsonConvert.DeserializeObject<ResultDataJson<TransactionDto>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<TransactionDto>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<TransactionDto> resultDataJson = new ResultDataJson<TransactionDto>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<TransactionDto>>(resultDataJson);
                        }
                    }
                }
            }
        }

        public async Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAll()
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "transaction/"))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError)
                        {
                            ResultDataJson<List<TransactionDto>>? result = JsonConvert.DeserializeObject<ResultDataJson<List<TransactionDto>>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<List<TransactionDto>>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<List<TransactionDto>> resultDataJson = new ResultDataJson<List<TransactionDto>>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<List<TransactionDto>>>(resultDataJson);
                        }
                    }
                }
            }
        }

        public async Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAllById(string id)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "transaction/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.NotFound && res.StatusCode != HttpStatusCode.InternalServerError)
                        {
                            ResultDataJson<List<TransactionDto>>? result = JsonConvert.DeserializeObject<ResultDataJson<List<TransactionDto>>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<List<TransactionDto>>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<List<TransactionDto>> resultDataJson = new ResultDataJson<List<TransactionDto>>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<List<TransactionDto>>>(resultDataJson);
                        }
                    }
                }
            }
        }

        public async Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAllByFromPersonelId(string fromPersonelId)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "transaction/getAllFromId/" + fromPersonelId))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError)
                        {
                            ResultDataJson<List<TransactionDto>>? result = JsonConvert.DeserializeObject<ResultDataJson<List<TransactionDto>>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<List<TransactionDto>>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<List<TransactionDto>> resultDataJson = new ResultDataJson<List<TransactionDto>>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<List<TransactionDto>>>(resultDataJson);
                        }
                    }
                }
            }
        }

        public async Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAllByToPersonelId(string toPersonelId)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "transaction/getAllToId/" + toPersonelId))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError)
                        {
                            ResultDataJson<List<TransactionDto>>? result = JsonConvert.DeserializeObject<ResultDataJson<List<TransactionDto>>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<List<TransactionDto>>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<List<TransactionDto>> resultDataJson = new ResultDataJson<List<TransactionDto>>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<List<TransactionDto>>>(resultDataJson);
                        }
                    }
                }
            }
        }

        public async Task<IJsonDataResult<ResultDataJson<TransactionDto>>> GetById(string id)
        {
            using (HttpClient client = BaseHttpClient.CreateHttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "transaction/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.Unauthorized && res.StatusCode != HttpStatusCode.InternalServerError && res.StatusCode != HttpStatusCode.NotFound)
                        {
                            ResultDataJson<TransactionDto>? result = JsonConvert.DeserializeObject<ResultDataJson<TransactionDto>>(data);
                            return new SuccessJsonDataResult<ResultDataJson<TransactionDto>>(result);
                        }
                        else
                        {
                            ResultJson? resultError = JsonConvert.DeserializeObject<ResultJson>(data);
                            ResultDataJson<TransactionDto> resultDataJson = new ResultDataJson<TransactionDto>();
                            resultDataJson.ErrorMessage = resultError.Error;
                            resultDataJson.Status = resultError.Success;
                            return new ErrorJsonDataResult<ResultDataJson<TransactionDto>>(resultDataJson);
                        }
                    }
                }
            }
        }
    }
}
