using Business.Services.InfoServices.Dtos;
using Core.Entities;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.JsonResults.Concrete;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Business.Services.InfoServices
{
    public class InfoManager : IInfoService
    {
        public async Task<IDataResult<ResultDataJson<CreatedInfoDto>>> Add(CreatedInfoDto createdInfoDto)
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
                            IDataResult<ResultDataJson<CreatedInfoDto>> result = new ConvertJsonDataResult<CreatedInfoDto>().JsonToData(data);
                            if (result.Success)
                            {
                                return new SuccessDataResult<ResultDataJson<CreatedInfoDto>>(result.Data);
                            }
                            return new ErrorDataResult<ResultDataJson<CreatedInfoDto>>(result.Data);
                        }
                    }
                }
            }
            return new ErrorDataResult<ResultDataJson<CreatedInfoDto>>(string.Empty);
        }

        public async Task<IDataResult<ResultDataJson<InfoDto>>> GetById(string id)
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(new BaseUrl().HostUrl + "info/getbyid?id=" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            IDataResult<ResultDataJson<InfoDto>> result = new ConvertJsonDataResult<InfoDto>().JsonToData(data);
                            if (result.Success)
                            {
                                return new SuccessDataResult<ResultDataJson<InfoDto>>(result.Data);
                            }
                            return new ErrorDataResult<ResultDataJson<InfoDto>>(result.Data);
                        }
                    }
                }
            }
            return new ErrorDataResult<ResultDataJson<InfoDto>>(string.Empty);
        }

        public async Task<IDataResult<ResultDataJson<UpdateInfoDto>>> Update(UpdateInfoDto updateInfoDto)
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsJsonAsync(new BaseUrl().HostUrl + "info/update", updateInfoDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            IDataResult<ResultDataJson<UpdateInfoDto>> result = new ConvertJsonDataResult<UpdateInfoDto>().JsonToData(data);

                            if (result.Success)
                            {
                                return new SuccessDataResult<ResultDataJson<UpdateInfoDto>>(result.Data);
                            }
                            return new ErrorDataResult<ResultDataJson<UpdateInfoDto>>(result.Data);
                        }
                    }
                }

            }
            return new ErrorDataResult<ResultDataJson<UpdateInfoDto>>(string.Empty);
        }
    }
}
