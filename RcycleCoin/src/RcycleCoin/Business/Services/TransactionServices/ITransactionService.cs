using Business.Services.TransactionServices.Dtos;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.TransactionServices
{
    public interface ITransactionService
    {
        public Task<IJsonDataResult<ResultDataJson<TransactionDto>>> GetById(string id);
        public Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAll();
        public Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAllById(string id);
        public Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAllByFromPersonelId(string fromPersonelId);
        public Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAllByToPersonelId(string toPersonelId);
        public Task<IJsonDataResult<ResultDataJson<TransactionDto>>> Add(CreatedTransactionDto createdTransactionDto);
    }
}
