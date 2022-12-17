using Business.Services.CoinServices.Dtos;
using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.CoinServices
{
    public interface ICoinService
    {
        public Task<IJsonDataResult<ResultDataJson<CoinDto>>> GetById(string id,string token);
        public Task<IJsonDataResult<ResultDataJson<CoinDto>>> Delete(string id, string token);
        public Task<IJsonDataResult<ResultDataJson<UpdatedCoinDto>>> Update(UpdatedCoinDto updatedCoinDto, string token);
    }
}
