using Business.Services.CoinServices.Dtos;
using Business.Services.InfoServices.Dtos;
using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.InfoServices
{
    public interface IInfoService
    {
        public Task<IJsonDataResult<ResultDataJson<InfoDto>>> Add(CreatedInfoDto createdInfoDto,string token);
        public Task<IJsonDataResult<ResultDataJson<InfoDto>>> Update(string id,UpdateInfoDto updateInfoDto, string token);
        public Task<IJsonDataResult<ResultDataJson<InfoDto>>> GetById(string id,string token);
    }
}
