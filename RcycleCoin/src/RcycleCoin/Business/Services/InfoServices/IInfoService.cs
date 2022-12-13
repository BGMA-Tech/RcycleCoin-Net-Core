using Business.Services.InfoServices.Dtos;
using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.InfoServices
{
    public interface IInfoService
    {
        public Task<IDataResult<ResultDataJson<CreatedInfoDto>>> Add(CreatedInfoDto createdInfoDto);
        public Task<IDataResult<ResultDataJson<UpdateInfoDto>>> Update(UpdateInfoDto updateInfoDto);
        public Task<IDataResult<ResultDataJson<InfoDto>>> GetById(string id);
    }
}
