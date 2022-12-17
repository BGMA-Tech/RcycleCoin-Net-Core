using Business.Services.CoinServices.Dtos;
using Business.Services.InfoServices.Dtos;
using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.InfoServices
{
    public interface IInfoService
    {
        public Task<IJsonDataResult<ResultDataJson<CreatedInfoDto>>> Add(CreatedInfoDto createdInfoDto);
        public Task<IJsonDataResult<ResultDataJson<UpdateInfoDto>>> Update(UpdateInfoDto updateInfoDto);
        public Task<IJsonDataResult<ResultDataJson<InfoDto>>> GetById(string id);
    }
}
