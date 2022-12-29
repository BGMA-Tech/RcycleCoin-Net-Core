using Business.Services.CoinServices.Dtos;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.CoinServices
{
    public interface ICoinService
    {
        public Task<IJsonDataResult<ResultDataJson<CoinDto>>> GetById(string id);
        public Task<IJsonDataResult<ResultDataJson<CoinDto>>> Delete(string id);
        public Task<IJsonDataResult<ResultDataJson<CoinDto>>> Update(string id,UpdatedCoinDto updatedCoinDto);
    }
}
