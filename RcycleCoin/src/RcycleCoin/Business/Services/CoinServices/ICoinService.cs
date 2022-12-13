using Business.Services.CoinServices.Dtos;
using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.CoinServices
{
    public interface ICoinService
    {
        public Task<IDataResult<ResultDataJson<CoinDto>>> GetById(string id);
        public Task<IDataResult<ResultDataJson<CoinDto>>> Delete(string id);
        public Task<IDataResult<ResultDataJson<UpdatedCoinDto>>> Update(UpdatedCoinDto updatedCoinDto);
    }
}
